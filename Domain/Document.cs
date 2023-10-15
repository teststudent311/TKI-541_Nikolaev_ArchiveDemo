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
        /// <param name="documentCode"> Код документа. </param>
        /// <param name="title"> Название. </param>
        /// <param name="inventory"> Опись. </param>
        /// <param name="readingRoom"> Читальный зал. </param>
        public Document(int documentCode, string title, Inventory inventory, ReadingRoom readingRoom)
        {
            this.DocumentCode = documentCode;
            this.Title = title.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(title));
            this.Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            this.ReadingRoom = readingRoom ?? throw new ArgumentNullException(nameof(readingRoom));
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
        /// Изменяет название документа.
        /// </summary>
        /// <param name="newTitle"> Новое название документа. </param>
        public virtual void ChangeTitle(string newTitle)
        {
            this.Title = newTitle.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(newTitle));
        }

        /// <inheritdoc/>
        public override string ToString() => this.Title;
    }
}
