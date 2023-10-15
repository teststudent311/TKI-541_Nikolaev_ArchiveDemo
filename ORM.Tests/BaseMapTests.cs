// <copyright file="BaseMapTests.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Tests
{
    using NHibernate;
    using NUnit.Framework;
    using ORM.Mappings;

    /// <summary>
    /// Базовый класс для тестирования маппингов.
    /// </summary>
    public abstract class BaseMapTests
    {
        /// <summary>
        /// Получает или устанавливает сессию для тестовой БД.
        /// </summary>
        protected ISession Session { get; private set; }

        /// <summary>
        /// Настраивает тестовое окружение перед каждым тестом.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.Session = NHibernateTestsConfigurator.BuildSessionForTest();
        }

        /// <summary>
        /// Освобождает ресурсы и выполняет очистку после теста.
        /// </summary>
        [TearDown]
        public void CloseSession() => this.Session?.Dispose();
    }
}