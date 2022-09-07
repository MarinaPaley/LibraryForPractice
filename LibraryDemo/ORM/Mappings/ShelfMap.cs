// <copyright file="ShelfMap.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Shelf"/> на таблицу и наоборот.
    /// </summary>
    internal class ShelfMap : ClassMap<Shelf>
    {
        public ShelfMap ()
        {
            this.Table("Shelves");

            this.Id(x => x.Id);

            this.Map(x => x.Name).Not.Nullable().Length(255);

            this.HasMany(x => x.Books).Not.Inverse();
        }
    }
}
