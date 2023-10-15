// <copyright file="DocumentMapTests.cs" company="Николаев А.М.">
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
    /// Класс для тестирования маппинга <see cref="DocumentMap"/>.
    /// </summary>
    [TestFixture]
    public class DocumentMapTests : BaseMapTests
    {
        /// <summary>
        /// Тест проверяет корректность маппинга для простого случая.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            var inventory = new Inventory(1, "Опись 1");
            var readingRoom = new ReadingRoom(1, "Читальный зал 1");

            // Создаем документ без установки идентификатора вручную
            var document = new Document(0, "Документ 1", inventory, readingRoom);

            // act & assert
            new PersistenceSpecification<Document>(this.Session, new CustomEqualityComparer())
                .CheckProperty(c => c.Title, "Документ 1")
                .CheckReference(c => c.Inventory, inventory)
                .CheckReference(c => c.ReadingRoom, readingRoom)
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

#pragma warning disable SA1305 // Field names should not use Hungarian notation
                if (!(x is not Inventory xInventory || y is not Inventory yInventory))
                {
                    return xInventory.Title == yInventory.Title;
                }
#pragma warning restore SA1305 // Field names should not use Hungarian notation

#pragma warning disable SA1305 // Field names should not use Hungarian notation
                return x is ReadingRoom xReadingRoom && y is ReadingRoom yReadingRoom ? xReadingRoom.Name == yReadingRoom.Name : x.Equals(y);
#pragma warning restore SA1305 // Field names should not use Hungarian notation
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
