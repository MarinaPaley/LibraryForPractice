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
        /// <summary>
        /// The to string_ valid data_ success.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            //arrange
            var author = new Author(1, "Носов", "Николай", "Николаевич");

            //act
            var result = author.ToString();
            //assert
            Assert.AreEqual("Носов Н. Н.", result);
        }

        /// <summary>
        /// The to string_ valid empty middle name_ success.
        /// </summary>
        [Test]
        public void ToString_ValidEmptyMiddleName_Success()
        {
            //arrange
            var author = new Author(1, "Носов", "Николай");

            //act
            var result = author.ToString();
            //assert
            Assert.AreEqual("Носов Н.", result);
        }

        /// <summary>
        /// The ctor_ wrong data_ empty first name_ fail.
        /// </summary>
        [Test]
        public void Ctor_WrongData_EmptyFirstName_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Author(1, "Носов", "", "Николаевич"));
        }

        /// <summary>
        /// The add book to author_ valid data_ success.
        /// </summary>
        [Test]
        public void AddBookToAuthor_ValidData_Success()
        {
            //arrange
            var author = new Domain.Author(1, "Носов", "Николай", "Николаевич");
            var book = new Domain.Book(1, "Незнайка");

            //act
            var result = author.AddBook(book);

            //assert
            Assert.AreEqual(true, result);
        }
    }
}