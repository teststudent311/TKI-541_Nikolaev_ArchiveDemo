// <copyright file="InventoryMap.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения объектов <see cref="Inventory"/> на таблицу базы данных и обратно.
    /// </summary>
    internal class InventoryMap : ClassMap<Inventory>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InventoryMap"/>, устанавливая правила отображения.
        /// </summary>
        public InventoryMap()
        {
            // Указание схемы базы данных (если применимо).
            // this.Schema("dbo");

            // Отображение класса Inventory на таблицу Inventories.
            this.Table("Inventories");

            // Отображение свойства InventoryCode как первичного ключа.
            this.Id(x => x.InventoryCode).Column("inventory_code");

            // Отображение свойства Title с условием, что оно не может быть NULL.
            this.Map(x => x.Title).Column("title").Not.Nullable().Length(255);
        }
    }
}
