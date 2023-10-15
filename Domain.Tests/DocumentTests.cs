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
            // arrange
            var document = new Document(1, "Паспорт", this.inventory, this.readingRoom);

            // act
            var result = document.ToString();

            // assert
            Assert.That(result, Is.EqualTo("Паспорт"));
        }

        /// <summary>
        /// Тестирование метода <see cref="Document.ChangeTitle"/> с корректными данными.
        /// </summary>
        [Test]
        public void ChangeTitle_ValidData_Success()
        {
            // arrange
            var document = new Document(1, "Паспорт", this.inventory, this.readingRoom);
            var newTitle = "Свидетельство о рождении";

            // act
            document.ChangeTitle(newTitle);
            var result = document.ToString();

            // assert
            Assert.That(result, Is.EqualTo(newTitle));
        }

        /// <summary>
        /// Тестирование метода <see cref="Document.ChangeTitle"/> с пустым названием.
        /// </summary>
        [Test]
        public void ChangeTitle_EmptyTitle_Fail()
        {
            // arrange
            var document = new Document(1, "Паспорт", this.inventory, this.readingRoom);

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => document.ChangeTitle(string.Empty));
        }

        /// <summary>
        /// Тестирование конструктора <see cref="Document"/> с пустым названием.
        /// </summary>
        [Test]
        public void Ctor_EmptyTitle_Fail()
        {
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Document(1, string.Empty, this.inventory, this.readingRoom));
        }
    }
}