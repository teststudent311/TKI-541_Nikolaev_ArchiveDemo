// <copyright file="DocumentMap.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="Document"/> на таблицу и наоборот.
    /// </summary>
    internal class DocumentMap : ClassMap<Document>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DocumentMap"/>.
        /// </summary>
        public DocumentMap()
        {
            // this.Schema("dbo");
            this.Table("documents");

            this.Id(x => x.DocumentCode).Column("document_code");

            this.Map(x => x.Title).Column("title").Not.Nullable().Length(255);

            // Ссылка на опись
            this.References(x => x.Inventory).Column("inventory_code").Not.Nullable().ForeignKey("fk_documents_inventories");

            // Ссылка на читальный зал
            this.References(x => x.ReadingRoom).Column("reading_room_code").Not.Nullable().ForeignKey("fk_documents_reading_rooms");
        }
    }
}