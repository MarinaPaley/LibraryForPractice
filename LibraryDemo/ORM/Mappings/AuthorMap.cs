// <copyright file="AuthorMap.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Author"/> на таблицу и наоборот.
    /// </summary>
    internal class AuthorMap : ClassMap<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AuthorMap"/>.
        /// </summary>
        public AuthorMap()
        {
            // this.Schema("dbo");

            this.Table("Authors");

            this.Id(x => x.Id);

            this.Map(x => x.FirstName).Not.Nullable();
            this.Map(x => x.LastName).Not.Nullable();
            this.Map(x => x.MiddleName);

            this.HasManyToMany(x => x.Books);
        }
    }
}
