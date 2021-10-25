// <copyright file="Program.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace LibraryDemo
{
    using System;

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
            var author = new Domain.Author(1, "Носов", "Николай");
            var book = new Domain.Book(1, "Незнайка", author);

            Console.WriteLine($"{book} {author}");
        }
    }
}
