// <copyright file="ReadingRoomMapTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using System.Collections;
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Класс для тестирования маппинга <see cref="ReadingRoomMap"/>.
    /// </summary>
    [TestFixture]
    public class ReadingRoomMapTests : BaseMapTests
    {
        /// <summary>
        /// Тест проверяет корректность маппинга для простого случая.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var readingRoom = new ReadingRoom(1, "Читальный зал 1");

            // act & assert
            new PersistenceSpecification<ReadingRoom>(this.Session, new CustomEqualityComparer())
                .CheckProperty(c => c.ReadingRoomCode, 1)
                .CheckProperty(c => c.Name, "Читальный зал 1")
                .VerifyTheMappings();
        }

        /// <summary>
        /// Класс для кастомного сравнения объектов в тестах.
        /// </summary>
        public class CustomEqualityComparer : IEqualityComparer
        {
            /// <summary>
            /// Метод для сравнения двух объектов на эквивалентность.
            /// </summary>
            /// <param name="x">Первый объект для сравнения.</param>
            /// <param name="y">Второй объект для сравнения.</param>
            /// <returns>Возвращает true, если объекты эквивалентны, иначе false.</returns>
#pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
            public new bool Equals(object x, object y)
#pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (x == null || y == null)
                {
                    return false;
                }

                return x is ReadingRoom xReadingRoom && y is ReadingRoom yReadingRoom ? xReadingRoom.Name == yReadingRoom.Name : x.Equals(y);
            }

            /// <summary>
            /// Метод для получения хэш-кода объекта.
            /// </summary>
            /// <param name="obj">Объект, для которого необходимо получить хэш-код.</param>
            /// <returns>Хэш-код объекта.</returns>
            public int GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
