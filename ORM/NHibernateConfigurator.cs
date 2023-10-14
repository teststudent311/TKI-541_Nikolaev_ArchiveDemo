// <copyright file="NHibernateConfigurator.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

namespace ORM
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// Класс для конфигурации NHibernate.
    /// </summary>
    public static class NHibernateConfigurator
    {
        private static FluentConfiguration? fluentConfiguration;

        /// <summary>
        /// Получает фабрику сессий.
        /// </summary>
        /// <param name="assembly">Сборка для маппинга.</param>
        /// <param name="showSql">Показывать SQL запросы.</param>
        /// <returns>Фабрика сессий.</returns>
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSql = false)
        {
            return GetConfiguration(assembly ?? Assembly.GetExecutingAssembly(), showSql)
                .BuildSessionFactory();
        }

        /// <summary>
        /// Получает конфигурацию.
        /// </summary>
        /// <param name="assembly">Сборка для маппинга.</param>
        /// <param name="showSql">Показывать SQL запросы.</param>
        /// <returns>Конфигурация.</returns>
        private static FluentConfiguration GetConfiguration(Assembly assembly = null, bool showSql = false)
        {
            if (fluentConfiguration is null)
            {
                var databaseConfiguration = SQLiteConfiguration.Standard
                    .InMemory();

                if (showSql)
                {
                    databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
                }

                fluentConfiguration = Fluently.Configure()
                    .Database(databaseConfiguration)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                    .ExposeConfiguration(BuildSchema);
            }

            return fluentConfiguration;
        }

        /// <summary>
        /// Строит схему базы данных.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}