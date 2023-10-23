// <copyright file="DocumentMap.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Document"/> на таблицу и наоборот.
    /// </summary>
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        /// <summary>
        /// Конфигурирует схему таблицы для <see cref="Document"/>.
        /// </summary>
        /// <param name="builder">Построитель сущности.</param>
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            // Указание имени таблицы
            builder.ToTable("documents");

            // Указание первичного ключа
            builder.HasKey(d => d.DocumentCode)
                .HasName("document_code");

            builder.Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");

            builder.HasOne(d => d.Inventory)
                .WithMany()
                .HasForeignKey(d => d.InventoryCode)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_documents_inventories");

            builder.HasOne(d => d.ReadingRoom)
                .WithMany()
                .HasForeignKey(d => d.ReadingRoomCode)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_documents_reading_rooms");
        }
    }
}