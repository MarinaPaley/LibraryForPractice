// <copyright file="AuthorTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// The author tests.
    /// </summary>
    [TestFixture]
    public class AuthorTests
    {
        private Book book;

        [SetUp]
        public void Setup()
        {
            this.book = new Book(1, "Незнайка");
        }

        //// private static Book GenerateBook() => new Book(1, "Незнайка");

        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var author = new Author(1, "Носов", "Николай", "Николаевич");

            // act
            var result = author.ToString();

            // assert
            Assert.AreEqual("Носов Н. Н.", result);
        }

        [Test]
        public void ToString_ValidEmptyMiddleName_Success()
        {
            // arrange
            var author = new Author(1, "Носов", "Николай");

            // act
            var result = author.ToString();

            // assert
            Assert.AreEqual("Носов Н.", result);
        }

        [Test]
        public void Ctor_WrongData_EmptyFirstName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Author(1, "Носов", string.Empty, "Николаевич"));
        }

        [Test]
        public void AddBookToAuthor_ValidData_Success()
        {
            // arrange
            var author = GetAuthor("Носов", "Николай", "Николаевич");

            // act
            var result = author.AddBook(this.book);

            // assert
            Assert.AreEqual(true, result);
        }

        private static Author GetAuthor(string lastName = null, string firstName = null, string middleName = null)
        {
            return new Author(1, lastName ?? "Тестовый", firstName ?? "Автор", middleName);
        }
    }
}
