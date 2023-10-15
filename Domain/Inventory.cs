// <copyright file="Inventory.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff.Extensions;

    /// <summary>
    /// Описывает опись.
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
        /// Изменить название описи.
        /// </summary>
        /// <param name="newTitle">Новое название.</param>
        public virtual void ChangeTitle(string newTitle)
        {
            this.Title = newTitle.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(newTitle));
        }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Title}";
    }
}
