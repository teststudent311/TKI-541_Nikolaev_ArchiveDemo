// <copyright file="InventoryMap.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Класс, описывающий правила отображения объектов <see cref="Inventory"/> на таблицу базы данных и обратно.
    /// </summary>
    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        /// <summary>
        /// Конфигурирует схему таблицы для <see cref="Inventory"/>.
        /// </summary>
        /// <param name="builder">Построитель сущности.</param>
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            // Указание имени таблицы
            builder.ToTable("inventories");

            // Указание первичного ключа
            builder.HasKey(i => i.InventoryCode)
                .HasName("inventory_code");

            builder.Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");
        }
    }
}