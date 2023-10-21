// <copyright file="InventoryMapTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using System.Linq;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    /// <summary>
    /// Класс для тестирования маппинга <see cref="Inventory"/>.
    /// </summary>
    [TestFixture]
    public class InventoryMapTests
    {
        /// <summary>
        /// Контекст базы данных для тестов.
        /// </summary>
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
            var inventory = new Inventory(1, "w");

            // Act
            this.context.Inventories.Add(inventory);
            this.context.SaveChanges();

            // Assert
            var savedInventory = this.context.Inventories.FirstOrDefault(i => i.Title == "w");
            Assert.That(savedInventory, Is.Not.Null);
            Assert.That(savedInventory.Title, Is.EqualTo("w"));
        }
    }
}