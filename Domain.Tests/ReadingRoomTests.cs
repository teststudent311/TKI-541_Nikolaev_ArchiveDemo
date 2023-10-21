// <copyright file="ReadingRoomTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace Domain.Tests
{
    using System;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для класса <see cref="ReadingRoom"/>.
    /// </summary>
    [TestFixture]
    public class ReadingRoomTests
    {
        /// <summary>
        /// Тестовый читальный зал.
        /// </summary>
        private ReadingRoom readingRoom;

        /// <summary>
        /// Установка тестового окружения.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.readingRoom = new ReadingRoom(1, "Главный зал");
        }

        /// <summary>
        /// Тест метода ToString с валидными данными.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Act
            var result = this.readingRoom.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("Код читального зала: 1, Название: Главный зал"));
        }

        /// <summary>
        /// Тест конструктора с неверными данными.
        /// </summary>
        [Test]
        public void Ctor_WrongData_EmptyName_Fail()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ReadingRoom(1, string.Empty));
        }

        /// <summary>
        /// Тест создания двух объектов ReadingRoom с одинаковыми значениями.
        /// </summary>
        [Test]
        public void Equals_WithSameValues_ReturnsTrue()
        {
            // Arrange
            var readingRoom1 = new ReadingRoom(1, "Главный зал");
            var readingRoom2 = new ReadingRoom(1, "Главный зал");

            // Act
            bool areEqual = readingRoom1.Equals(readingRoom2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        /// <summary>
        /// Тест создания двух объектов ReadingRoom с разными значениями Name.
        /// </summary>
        [Test]
        public void Equals_WithDifferentName_ReturnsFalse()
        {
            // Arrange
            var readingRoom1 = new ReadingRoom(1, "Главный зал");
            var readingRoom2 = new ReadingRoom(1, "Малый зал");

            // Act
            bool areEqual = readingRoom1.Equals(readingRoom2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        /// <summary>
        /// Тест конструктора с неверными данными.
        /// </summary>
        [Test]
        public void Ctor_WrongData_NullName_Fail()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ReadingRoom(1, null));
        }
    }
}