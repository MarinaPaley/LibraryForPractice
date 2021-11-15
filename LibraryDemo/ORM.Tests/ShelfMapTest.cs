// <copyright file="ShelfMapTest.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для класса <see cref="ORM.Mappings.ShelfMap"/>.
    /// </summary>
    public class ShelfMapTest : BaseMapTests
    {
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var shelf = new Shelf(1, "Тестовая полка");

            // act & assert
            new PersistenceSpecification<Shelf>(this.Session)
                .VerifyTheMappings(shelf);

        }
    }
}
