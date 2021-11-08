// <copyright file="BaseMapTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

using NHibernate.Tool.hbm2ddl;

namespace ORM.Tests
{
    using NHibernate;
    using NUnit.Framework;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseMapTests
    {
        /// <summary>
        /// 
        /// </summary>
        protected ISessionFactory SessionFactory { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected ISession Session { get; private set; }

        [OneTimeSetUp]
        public void SetUpOnce()
        {
            this.SessionFactory = NHibernateConfigurator.GetSessionFactory(tests: true, showSql: true);
        }

        [OneTimeTearDown]
        public void Terminate() => this.SessionFactory?.Dispose();

        [SetUp]
        public void Setup()
        {
            this.Session = this.SessionFactory.OpenSession();
        }

        [TearDown]
        public void CloseSession() => this.Session?.Dispose();
    }
}
