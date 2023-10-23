// <copyright file="InventoryTests.cs" company="Николаев А.М.">
// Copyright (Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Класс, содержащий тесты для <see cref="Inventory"/>.
    /// </summary>
    [TestFixture]
    public class InventoryTests
    {
        /// <summary>
        /// Объект документа для тестирования.
        /// </summary>
        private Document document;

        /// <summary>
        /// Метод, который выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var inventory = new Inventory(1001, "Опись 1");
            var readingRoom = new ReadingRoom(101, "Читальный зал 1");
            this.document = new Document(1, "Договор", inventory, readingRoom);
        }

        /// <summary>
        /// Тестирование метода <see cref="Inventory.ToString"/> на корректность возвращаемой строки.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var inventory = new Inventory(1001, "Опись 1");

            // Act
            var result = inventory.ToString();

            // Assert
            Assert.That(result, Does.Contain("Опись 1"));
        }

        /// <summary>
        /// Тестирование конструктора <see cref="Inventory"/> на выброс исключения при передаче пустого названия.
        /// </summary>
        [Test]
        public void Ctor_WrongData_EmptyTitle_Fail()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Inventory(1001, string.Empty));
        }

        /// <summary>
        /// Тестирование метода <see cref="Inventory.SetName"/> на корректность изменения названия описи.
        /// </summary>
        [Test]
        public void SetName_ValidData_Success()
        {
            // Arrange
            var inventory = new Inventory(1001, "Опись 1");

            // Act
            inventory.SetName("Опись 2");

            // Assert
            Assert.That(inventory.ToString(), Does.Contain("Опись 2"));
        }

        /// <summary>
        /// Тестирование метода <see cref="Inventory.SetName"/> на выброс исключения при передаче пустого значения.
        /// </summary>
        [Test]
        public void SetName_EmptyTitle_Fail()
        {
            // Arrange
            var inventory = GetInventory("Опись 1");

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => inventory.SetName(string.Empty));
        }

        /// <summary>
        /// Тест создания двух объектов Inventory с одинаковыми значениями.
        /// </summary>
        [Test]
        public void Equals_WithSameValues_ReturnsTrue()
        {
            // Arrange
            var inventory1 = new Inventory(1, "Опись 1");
            var inventory2 = new Inventory(1, "Опись 1");

            // Act
            bool areEqual = inventory1.Equals(inventory2);

            // Assert
            Assert.That(areEqual, Is.True);
        }

        /// <summary>
        /// Тест создания двух объектов Inventory с разными значениями Title.
        /// </summary>
        [Test]
        public void Equals_WithDifferentTitle_ReturnsFalse()
        {
            // Arrange
            var inventory1 = new Inventory(1, "Опись 1");
            var inventory2 = new Inventory(1, "Опись 2");

            // Act
            bool areEqual = inventory1.Equals(inventory2);

            // Assert
            Assert.That(areEqual, Is.False);
        }

        /// <summary>
        /// Получение объекта <see cref="Inventory"/> для тестирования.
        /// </summary>
        /// <param name="title">Название описи.</param>
        /// <returns>Объект <see cref="Inventory"/>.</returns>
        private static Inventory GetInventory(string title = null)
        {
            return new Inventory(1001, title ?? "Тестовая опись");
        }
    }
}