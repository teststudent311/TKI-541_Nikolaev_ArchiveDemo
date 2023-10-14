// <copyright file="ReadingRoom.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Collections.Generic;
    using Staff.Extensions;

    /// <summary>
    /// Читальный зал.
    /// </summary>
    public class ReadingRoom
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ReadingRoom"/>.
        /// </summary>
        /// <param name="code">Код читального зала.</param>
        /// <param name="name">Название читального зала.</param>
        public ReadingRoom(int code, string name)
        {
            this.ReadingRoomCode = code;
            this.Name = name.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(name));
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ReadingRoom"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        protected ReadingRoom()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
        }

        /// <summary>
        /// Уникальный код читального зала.
        /// </summary>
        public virtual int ReadingRoomCode { get; protected set; }

        /// <summary>
        /// Название читального зала.
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <inheritdoc/>
        public override string ToString() => $"{this.Name}";

        public static implicit operator ReadingRoom(int v)
        {
            throw new NotImplementedException();
        }
    }
}
