// <copyright file="BookMap.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Book"/> на таблицу и наоборот.
    /// </summary>
    internal class BookMap : ClassMap<Book>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BookMap"/>.
        /// </summary>
        public BookMap()
        {
            this.Schema("dbo");

            this.Table("Books");

            this.Id(x => x.Id);

            this.Map(x => x.Title);

            this.HasManyToMany(x => x.Authors).Inverse();
        }
    }
}
