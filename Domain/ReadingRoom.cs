// <copyright file="ReadingRoom.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
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
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public ReadingRoom(int code, string name)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            this.ReadingRoomCode = code;
            this.SetName(name);
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

        /// <summary>
        /// Устанавливает новое значение для свойства Name.
        /// </summary>
        /// <param name="name">Новое значение для свойства Name.</param>
        public void SetName(string name)
        {
            this.Name = name.TrimOrNull() ?? throw new ArgumentOutOfRangeException(nameof(name));
        }

        /// <summary>
        /// Сравнивает текущий объект с другим объектом того же типа.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Возвращает true, если объекты равны, иначе false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is ReadingRoom other)
            {
                return this.ReadingRoomCode == other.ReadingRoomCode &&
                       this.Name == other.Name;
            }

            return false;
        }

        /// <summary>
        /// Возвращает хеш-код для текущего объекта.
        /// </summary>
        /// <returns>Хеш-код текущего объекта.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ReadingRoomCode, this.Name);
        }

        /// <summary>
        /// Возвращает строковое представление текущего объекта.
        /// </summary>
        /// <returns>Строковое представление текущего объекта.</returns>
        public override string ToString()
        {
            return $"Код читального зала: {this.ReadingRoomCode}, Название: {this.Name}";
        }
    }
}