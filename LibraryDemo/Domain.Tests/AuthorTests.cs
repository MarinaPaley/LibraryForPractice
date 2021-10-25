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
            Assert.Throws<ArgumentOutOfRangeException>(() => new Author(1, "Носов", string.Empty, "Николаевич"));
        }

        [Test]
        public void AddBookToAuthor_ValidData_Success()
        {
            // arrange
            var author = new Domain.Author(1, "Носов", "Николай", "Николаевич");

            var book = new Domain.Book(1, "Незнайка");

            // act
            var result = author.AddBook(book);

            // assert
            Assert.AreEqual(true, result);
        }
    }
}
