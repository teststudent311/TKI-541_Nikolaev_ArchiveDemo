// <copyright file="ReadingRoomMapTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using System.Linq;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    /// <summary>
    /// Класс для тестирования маппинга <see cref="ReadingRoom"/>.
    /// </summary>
    [TestFixture]
    public class ReadingRoomMapTests
    {
        private AppDbContext context;

        /// <summary>
        /// Настройка тестового окружения.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            this.context = new AppDbContext(options);
        }

        /// <summary>
        /// Очистка тестового окружения.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.context.Dispose();
        }

        /// <summary>
        /// Тест проверяет корректность маппинга для простого случая.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // Arrange
            var readingRoom = new ReadingRoom(1, "Читальный зал 1");

            // Act
            this.context.ReadingRooms.Add(readingRoom);
            this.context.SaveChanges();

            // Assert
            var savedReadingRoom = this.context.ReadingRooms.FirstOrDefault(r => r.Name == "Читальный зал 1");
            Assert.That(savedReadingRoom, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(savedReadingRoom.ReadingRoomCode, Is.EqualTo(1));
                Assert.That(savedReadingRoom.Name, Is.EqualTo("Читальный зал 1"));
            });
        }
    }
}