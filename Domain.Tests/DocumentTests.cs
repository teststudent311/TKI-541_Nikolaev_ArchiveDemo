// <copyright file="DocumentTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="Document"/>.
    /// </summary>
    [TestFixture]
    public class DocumentTests
    {
        private Inventory inventory;
        private ReadingRoom readingRoom;

        /// <summary>
        /// Настройка тестового окружения.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.inventory = new Inventory(1, "Опись 1");
            this.readingRoom = new ReadingRoom(1, "Читальный зал 1");
        }

        /// <summary>
        /// Тестирование метода <see cref="Document.ToString"/>.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var document = new Document(1, "Паспорт", this.inventory, this.readingRoom);

            // Act
            var result = document.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("Код документа: 1, Название: Паспорт, Код описи: 1, Код читального зала: 1"));
        }

        /// <summary>
        /// Тестирование метода <see cref="Document.SetName"/> с корректными данными.
        /// </summary>
        [Test]
        public void SetName_ValidData_Success()
        {
            // Arrange
            var document = new Document(1, "Паспорт", this.inventory, this.readingRoom);
            var newTitle = "Свидетельство о рождении";

            // Act
            document.SetName(newTitle);
            var result = document.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("Код документа: 1, Название: Свидетельство о рождении, Код описи: 1, Код читального зала: 1"));
        }

        /// <summary>
        /// Тестирование метода <see cref="Document.SetName"/> с пустым названием.
        /// </summary>
        [Test]
        public void SetName_EmptyTitle_Fail()
        {
            // Arrange
            var document = new Document(1, "Паспорт", this.inventory, this.readingRoom);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => document.SetName(string.Empty));
        }

        /// <summary>
        /// Тест создания двух объектов Document с одинаковыми значениями.
        /// </summary>
        [Test]
        public void Equals_WithSameValues_ReturnsTrue()
        {
            // Arrange
            var document1 = new Document(1, "Паспорт", this.inventory, this.readingRoom);
            var document2 = new Document(1, "Паспорт", this.inventory, this.readingRoom);

            // Act
            bool areEqual = document1.Equals(document2);

            // Assert
            Assert.That(areEqual, Is.True);
        }

        /// <summary>
        /// Тест создания двух объектов Document с разными значениями Title.
        /// </summary>
        [Test]
        public void Equals_WithDifferentTitle_ReturnsFalse()
        {
            // Arrange
            var document1 = new Document(1, "Паспорт", this.inventory, this.readingRoom);
            var document2 = new Document(1, "Свидетельство о рождении", this.inventory, this.readingRoom);

            // Act
            bool areEqual = document1.Equals(document2);

            // Assert
            Assert.That(areEqual, Is.False);
        }

        /// <summary>
        /// Тестирование конструктора <see cref="Document"/> с пустым названием.
        /// </summary>
        [Test]
        public void Ctor_EmptyTitle_Fail()
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Document(1, string.Empty, this.inventory, this.readingRoom));
        }
    }
}