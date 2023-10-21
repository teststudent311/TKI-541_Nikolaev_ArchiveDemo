// <copyright file="Document.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Документ.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Document"/>.
        /// </summary>
        /// <param name="documentCode">Код документа.</param>
        /// <param name="title">Название.</param>
        /// <param name="inventory">Опись.</param>
        /// <param name="readingRoom">Читальный зал.</param>
        public Document(int documentCode, string title, Inventory inventory, ReadingRoom readingRoom)
        {
            this.DocumentCode = documentCode;
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));
            this.Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            this.ReadingRoom = readingRoom ?? throw new ArgumentNullException(nameof(readingRoom));
            this.InventoryCode = inventory.InventoryCode;
            this.ReadingRoomCode = readingRoom.ReadingRoomCode;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Document"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        protected Document()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
        }

        /// <summary>
        /// Уникальный код документа.
        /// </summary>
        public virtual int DocumentCode { get; protected set; }

        /// <summary>
        /// Название.
        /// </summary>
        public virtual string Title { get; protected set; }

        /// <summary>
        /// Опись.
        /// </summary>
        public virtual Inventory Inventory { get; protected set; }

        /// <summary>
        /// Читальный зал.
        /// </summary>
        public virtual ReadingRoom ReadingRoom { get; protected set; }

        /// <summary>
        /// Код описи.
        /// </summary>
        public virtual int InventoryCode { get; protected set; }

        /// <summary>
        /// Код читального зала.
        /// </summary>
        public virtual int ReadingRoomCode { get; protected set; }

        /// <summary>
        /// Устанавливает новое название документа.
        /// </summary>
        /// <param name="newName">Новое название документа.</param>
        public virtual void SetName(string newName)
        {
            this.Title = newName.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(newName));
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом того же типа.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Возвращает true, если объекты равны, иначе false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Document other)
            {
                return this.DocumentCode == other.DocumentCode &&
                       this.Title == other.Title &&
                       this.InventoryCode == other.InventoryCode &&
                       this.ReadingRoomCode == other.ReadingRoomCode;
            }

            return false;
        }

        /// <summary>
        /// Возвращает хеш-код для текущего объекта.
        /// </summary>
        /// <returns>Хеш-код текущего объекта.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.DocumentCode, this.Title, this.InventoryCode, this.ReadingRoomCode);
        }

        /// <summary>
        /// Возвращает строковое представление текущего объекта.
        /// </summary>
        /// <returns>Строковое представление текущего объекта.</returns>
        public override string ToString()
        {
            return $"Код документа: {this.DocumentCode}, Название: {this.Title}, Код описи: {this.InventoryCode}, Код читального зала: {this.ReadingRoomCode}";
        }
    }
}