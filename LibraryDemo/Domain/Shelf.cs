// <copyright file="Shelf.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Staff.Extensions;

namespace Domain
{
    public class Shelf
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Shelf()
        {
        }

        public Shelf(int id, string name)
        {
            this.Name = name.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(name));
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Название полки.
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Коллекция книг.
        /// </summary>
        public virtual ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        /// <summary>
        /// Положить книгу на полку.
        /// </summary>
        /// <param name="book"> Книга. </param>
        /// <returns> <see langword="true"/> если книга была добавлена. </returns>
        public virtual bool AddBook(Book book)
        {
            return this.Books.TryAdd(book) ?? throw new ArgumentNullException(nameof(book));
        }
    }
}
