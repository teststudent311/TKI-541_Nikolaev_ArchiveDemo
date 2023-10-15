// <copyright file="ReadingRoomMap.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс, описывающий правила отображения <see cref="ReadingRoom"/> на таблицу и наоборот.
    /// </summary>
    internal class ReadingRoomMap : ClassMap<ReadingRoom>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ReadingRoomMap"/>.
        /// </summary>
        public ReadingRoomMap()
        {
            // this.Schema("dbo");
            this.Table("ReadingRooms");

            this.Id(x => x.ReadingRoomCode);

            this.Map(x => x.Name).Not.Nullable();
        }
    }
}