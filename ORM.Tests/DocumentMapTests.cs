// <copyright file="DocumentMapTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using System.Linq;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Тесты для проверки корректности отображения сущности <see cref="Document"/> на таблицу и наоборот.
    /// </summary>
    [TestFixture]
    public class DocumentMapTests
    {
        private AppDbContext context;

        /// <summary>
        /// Настройка тестового окружения.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.context = EFCoreTestsConfigurator.BuildContextForTest();
        }

        /// <summary>
        /// Очистка тестового окружения.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
            this.context.Dispose();
        }

        /// <summary>
        /// Тест проверяет, что сущность <see cref="Document"/> корректно сохраняется в базу данных с правильными связями.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // Arrange
            var inventory = new Inventory(1, "Опись 1");
            var readingRoom = new ReadingRoom(1, "Читальный зал 1");

            var document = new Document(1, "Документ 1", inventory, readingRoom);

            this.context.Inventories.Add(inventory);
            this.context.ReadingRooms.Add(readingRoom);
            this.context.Documents.Add(document);
            this.context.SaveChanges();

            // Act
            var savedDocument = this.context.Documents
                .Include(d => d.Inventory)
                .Include(d => d.ReadingRoom)
                .FirstOrDefault(d => d.Title == "Документ 1");

            // Assert
            Assert.That(savedDocument, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(savedDocument.Title, Is.EqualTo("Документ 1"));
                Assert.That(savedDocument.Inventory.Title, Is.EqualTo("Опись 1"));
                Assert.That(savedDocument.ReadingRoom.Name, Is.EqualTo("Читальный зал 1"));
            });
        }
    }
}