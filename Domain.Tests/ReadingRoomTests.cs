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
            // act
            var result = this.readingRoom.ToString();

            // assert
            Assert.That(result, Is.EqualTo("Главный зал"));
        }

        /// <summary>
        /// Тест конструктора с неверными данными.
        /// </summary>
        [Test]
        public void Ctor_WrongData_EmptyName_Fail()
        {
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ReadingRoom(1, string.Empty));
        }

        /// <summary>
        /// Тест конструктора с неверными данными.
        /// </summary>
        [Test]
        public void Ctor_WrongData_NullName_Fail()
        {
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ReadingRoom(1, null));
        }
    }
}
