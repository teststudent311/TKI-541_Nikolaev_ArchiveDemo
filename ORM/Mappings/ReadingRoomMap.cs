// <copyright file="ReadingRoomMap.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="ReadingRoom"/> на таблицу и наоборот.
    /// </summary>
    public class ReadingRoomMap : IEntityTypeConfiguration<ReadingRoom>
    {
        /// <summary>
        /// Конфигурирует схему, необходимую для отображения сущности <see cref="ReadingRoom"/>.
        /// </summary>
        /// <param name="builder">Построитель сущности.</param>
        public void Configure(EntityTypeBuilder<ReadingRoom> builder)
        {
            // Указание имени таблицы
            builder.ToTable("reading_rooms");

            // Указание первичного ключа
            builder.HasKey(r => r.ReadingRoomCode)
                .HasName("reading_room_code");

            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnName("name");
        }
    }
}