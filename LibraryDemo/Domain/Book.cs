// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;

    using Staff.Extensions;

    /// <summary>
    /// Книга.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="title">Название книги.</param>
        /// <param name="authors">Список авторов.</param>
        public Book(int id, string title, params Author[] authors)
            : this(id, title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="title">Название книги.</param>
        /// <param name="authors">Список авторов.</param>
        public Book(int id, string title, ISet<Author> authors = null)
        {
            this.Id = id;

            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));

            if (authors != null)
            {
                foreach (var author in authors)
                {
                    this.Authors.Add(author);
                    author.AddBook(this);
                }
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Book"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        protected Book()
        {
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public virtual string Title { get; protected set; }

        /// <summary>
        /// Список авторов.
        /// </summary>
        public virtual ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        /// <summary>
        /// Полка.
        /// </summary>
        public virtual Shelf Shelf { get; protected set; }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Title} {this.Authors.Join()}";
    }
}
