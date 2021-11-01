// <copyright file="NHibernateConfigurator.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
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
    /// Класс для настройки NHibernate.
    /// </summary>
    public static class NHibernateConfigurator
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        private static FluentConfiguration fluentConfiguration;

        /// <summary>
        /// Фабрика сессий (<see cref = "ISessionFactory"/>).
        /// </summary>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="showSql"> Показывать генерируемый SQL-код. </param>
        /// <returns> Фабрику сессий. </returns>
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSql = false)
        {
            return GetConfiguration(assembly ?? Assembly.GetExecutingAssembly(), showSql)
                .BuildSessionFactory();
        }

        /// <summary>
        /// Метод, который создает конфигурацию по сборке.
        /// </summary>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="showSql"> Показывать ли SQL-код. </param>
        /// <returns> Конфигурацию. </returns>
        private static FluentConfiguration GetConfiguration(Assembly assembly, bool showSql = false)
        {
            if (fluentConfiguration is not null)
            {
                return fluentConfiguration;
            }

            var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(
                x => x
                    .Server(@"LAPTOP-2ALR8J1J\SQLEXPRESS")
                    .Database("DemoLibrary")
                    .TrustedConnection());

            if (showSql)
            {
                databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
            }

            fluentConfiguration = Fluently.Configure()
                .Database(databaseConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                .ExposeConfiguration(BuildSchema);

            return fluentConfiguration;
        }

        /// <summary>
        /// Метод, который создает таблицы, если их не было в схеме по конфигурации.
        /// </summary>
        /// <param name="configuration"> Конфигурация ORM, которая содержит правила отображения.</param>
        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}
