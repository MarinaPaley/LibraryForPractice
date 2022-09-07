// <copyright file="AuthorMapTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="ORM.Mappings.AuthorMap"/>.
    /// </summary>
    public class AuthorMapTests : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var author = new Author(1, "Носов", "Николай", "Николаевич");

            // act & assert
            new PersistenceSpecification<Author>(this.Session)
                .VerifyTheMappings(author);
        }
    }
}
