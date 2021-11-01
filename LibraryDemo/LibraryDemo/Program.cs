// <copyright file="Program.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace LibraryDemo
{
    using System;
    using Domain;
    using ORM;

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
            session.Save(author);
            session.Save(book);
            session.Flush();
        }
    }
}
