// <copyright file="Inventory.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Опись.
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Inventory"/>.
        /// </summary>
        /// <param name="inventoryCode">Код описи.</param>
        /// <param name="title">Название описи.</param>
        public Inventory(int inventoryCode, string title)
        {
            this.InventoryCode = inventoryCode;
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Inventory"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        protected Inventory()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
        }

        /// <summary>
        /// Уникальный код описи.
        /// </summary>
        public virtual int InventoryCode { get; protected set; }

        /// <summary>
        /// Название описи.
        /// </summary>
        public virtual string Title { get; protected set; }

        /// <summary>
        /// Изменяет название описи.
        /// </summary>
        /// <param name="newTitle">Новое название описи.</param>
        public virtual void ChangeTitle(string newTitle)
        {
            this.Title = newTitle.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(newTitle));
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом того же типа.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Возвращает true, если объекты равны, иначе false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Inventory other)
            {
                return this.InventoryCode == other.InventoryCode &&
                       this.Title == other.Title;
            }

            return false;
        }

        /// <summary>
        /// Возвращает хеш-код для текущего объекта.
        /// </summary>
        /// <returns>Хеш-код текущего объекта.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.InventoryCode, this.Title);
        }

        /// <summary>
        /// Возвращает строковое представление текущего объекта.
        /// </summary>
        /// <returns>Строковое представление текущего объекта.</returns>
        public override string ToString()
        {
            return $"Код описи: {this.InventoryCode}, Название: {this.Title}";
        }
    }
}