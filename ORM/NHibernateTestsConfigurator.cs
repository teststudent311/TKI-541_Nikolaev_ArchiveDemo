// <copyright file="NHibernateTestsConfigurator.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM.Mappings
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// Класс для конфигурации тестов с использованием NHibernate.
    /// </summary>
    public class NHibernateTestsConfigurator
    {
        private static Configuration? configuration;

        /// <summary>
        /// Получает фабрику сессий для тестов.
        /// </summary>
        /// <param name="assembly">Сборка для маппинга.</param>
        /// <param name="showSql">Показывать SQL запросы.</param>
        /// <returns>Фабрика сессий.</returns>
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSql = false)
        {
            var databaseConfiguration = SQLiteConfiguration.Standard
                .InMemory();

            if (showSql)
            {
                databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
            }

            return Fluently.Configure()
                .Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly ?? Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(c => configuration = c)
                .BuildSessionFactory();
        }

        /// <summary>
        /// Строит сессию для тестов.
        /// </summary>
        /// <param name="showSql">Показывать SQL запросы.</param>
        /// <returns>Сессия.</returns>
        public static ISession BuildSessionForTest(bool showSql = true)
        {
            var session = GetSessionFactory(showSql: showSql).OpenSession();
            new SchemaExport(configuration)
                .Execute(true, true, false, session.Connection, null);
            return session;
        }
    }
}