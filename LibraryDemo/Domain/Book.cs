// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

using System.Linq;
using Staff.Extensions;

namespace Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Книга.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="authors"></param>
        public Book(int id, string title, params Author[] authors)
            : this(id, title, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="authors"></param>
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
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Список авторов.
        /// </summary>
        public ISet<Author> Authors { get; protected set; } = new HashSet<Author>();

        public override string ToString()
        {
            return $"{this.Title} {this.Authors.Join()}";
        }
    }

}
