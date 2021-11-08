// <copyright file="BookMapTest.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="ORM.Mappings.BookMap"/>.
    /// </summary>
    [TestFixture]
    public class BookMapTest : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidSimpleData_Success()
        {
            // arrange
            var book = new Book(1, "Библия");

            // act & assert
            new PersistenceSpecification<Book>(this.Session)
                .VerifyTheMappings(book);
        }

        [Test]
        public void PersistenceSpecification_ValidComplexData_Success()
        {
            // arrange
            var author = new Author(1, "Носов", "Николай", "Николаевич");

            var book = new Book(1, "Незнайка на Луне", author);

            // act & assert
            new PersistenceSpecification<Book>(this.Session)
                //.CheckBag(x => x.Authors, new[] { author })
                .VerifyTheMappings(book);
        }
    }
}
