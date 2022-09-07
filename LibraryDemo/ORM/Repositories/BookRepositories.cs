// <copyright file="BookRepositories.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// 
    /// </summary>
    public class BookRepositories : IRepository<Book>
    {
        private readonly ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public BookRepositories(ISession session)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<Book> Filter(Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Book Find(Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Book Get(int id)
        {
            return this.session.Get<Book>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<Book> GetAll()
        {
            return this.session.Query<Book>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Save(Book entity)
        {
            if (entity == null)
            {
                return false;
            }

            this.session.Save(entity);
            this.session.Flush();
            return true;
        }
    }
}
