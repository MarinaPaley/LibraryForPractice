﻿// <copyright file="Author.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Автор.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="lastName"> Фамилия.</param>
        /// <param name="firstName">Имя.</param>
        /// <param name="middleName">Отчество.</param>
        public Author(int id, string lastName, string firstName, string middleName = null)
        {
            this.Id = id;
            this.LastName = lastName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(lastName));
            this.FirstName = firstName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(firstName));
            this.MiddleName = middleName.TrimOrNull();
        }

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// имя.
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; protected set; }

        /// <summary>
        /// Список книг автора.
        /// </summary>
        public ISet<Book> Books { get; protected set; } = new HashSet<Book>();

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName => this.MiddleName != null
            ? $"{this.LastName} {this.FirstName[0]}. {this.MiddleName[0]}.".Trim()
            : $"{this.LastName} {this.FirstName[0]}.".Trim();

    /// <summary>
        /// Добавить книгу автору.
        /// </summary>
        /// <param name="book"> Добавляемая книга. </param>
        /// <returns>
        /// <see langword="true"/> если книга была добавлена.
        /// </returns>
        public bool AddBook(Book book)
        {
            var answer = this.Books.TryAdd(book) ?? throw new ArgumentNullException(nameof(book));
            return answer;
        }

    /// <inheritdoc/>
        public override string ToString() => this.FullName;
    }
}