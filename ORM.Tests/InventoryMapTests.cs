// <copyright file="InventoryMapTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using System.Data.Common;
    using Domain;
    using FluentNHibernate.Testing;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Класс для тестирования маппинга <see cref="InventoryMap"/>.
    /// </summary>
    [TestFixture]
    public class InventoryMapTests : BaseMapTests
    {
        /// <summary>
        /// Тест проверяет корректность маппинга для простого случая.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            Inventory inventory = new (1, "w");

            // act & assert
            new PersistenceSpecification<Inventory>(this.Session)
                .VerifyTheMappings(inventory);
        }
    }
}
