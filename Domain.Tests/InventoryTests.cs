// <copyright file="InventoryTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
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
            // arrange
            var inventory = new Inventory(1001, "Опись 1");

            // act
            var result = inventory.ToString();

            // assert
            Assert.That(result, Is.EqualTo("Опись 1"));
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
        /// Тестирование метода <see cref="Inventory.ChangeTitle"/> на корректность изменения названия описи.
        /// </summary>
        [Test]
        public void ChangeTitle_ValidData_Success()
        {
            // arrange
            var inventory = GetInventory("Опись 1");

            // act
            inventory.ChangeTitle("Опись 2");

            // assert
            Assert.That(inventory.ToString(), Is.EqualTo("Опись 2"));
        }

        /// <summary>
        /// Тестирование метода <see cref="Inventory.ChangeTitle"/> на выброс исключения при передаче пустого значения.
        /// </summary>
        [Test]
        public void ChangeTitle_EmptyTitle_Fail()
        {
            // arrange
            var inventory = GetInventory("Опись 1");

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => inventory.ChangeTitle(string.Empty));
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
