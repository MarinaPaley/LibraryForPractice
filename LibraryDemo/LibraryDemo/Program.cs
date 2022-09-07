// <copyright file="Program.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace LibraryDemo
{
    using System;
    using Domain;
    using ORM;
using ORM.Repositories;

/// <summary>
/// The program.
/// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            var author = new Author(1, "Носов", "Николай");

            var book = new Book(1, "Незнайка", author);

            Console.WriteLine($"{book} --> {author}");

            using var sessionFactory = NHibernateConfigurator.GetSessionFactory(showSql: true);
            using var session = sessionFactory.OpenSession();
            var bookRepo = new BookRepositories(session);
            bookRepo.Save(book);

            session.Save(author);
            //session.Save(book);
            session.Flush();

            var foundBook = bookRepo.Find(x => x.Title == "Незнайка");
            Console.WriteLine(foundBook);
        }
    }
}
