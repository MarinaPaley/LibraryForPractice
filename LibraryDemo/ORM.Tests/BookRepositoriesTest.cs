// <copyright file="BookRepositoriesTest.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace ORM.Tests
{
    using Domain;
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;
    using ORM.Repositories;

    internal class BookRepositoriesTest
    {
        /// <summary>
        /// Модульные тесты для <see cref="BookRepository"/>.
        /// </summary>
        [TestFixture]
        public class BookRepositoryTests
        {
            [Test]
            public void Get_ValidId_Success()
            {
                // arrange
                var targetId = 1;

                using var session = GetSession();

                PrepareBookInStorage(session, targetId);

                var repository = GetRepository(session);

                // act
                var result = repository.Get(targetId);

                // assert
                Assert.IsNotNull(result);
                Assert.AreEqual(targetId, result.Id);
            }

            private static void PrepareBookInStorage(ISession session, int targetId)
            {
                var book = new Book(targetId, "Тестовая");

                session.Save(book);
                session.Flush();
                session.Clear();
            }

            private static BookRepositories GetRepository(ISession session = null) => new (session ?? GetSession());

            private static ISession GetSession() => NHibernateTestsConfigurator.BuildSessionForTest(showSql: true);
        }
    }
}
