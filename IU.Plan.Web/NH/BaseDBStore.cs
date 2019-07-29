﻿using System;
using System.Collections.Generic;
using IU.PlanManager.ConApp;

namespace IU.Plan.Web.NH
{
    /// <summary>
    /// Хранилище событий <see cref="IEntity"/>
    /// </summary>
    public class BaseDBStore<T> : IStore<T>
        where T : class, IEntity
    {
        public virtual IEnumerable<T> Entities
        {
            get
            {
                var session = NHibernateHelper.GetCurrentSession();
                var entities = session.QueryOver<T>().List<T>();
                NHibernateHelper.CloseSession();
                return entities;
            }
        }

        public void Add(T entity)
        {
            Update(entity);
        }

        public virtual void Delete(Guid uid)
        {
            var session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (var tx = session.BeginTransaction())
                {
                    var entity = session.Load<T>(uid);
                    if (entity != null)
                    {
                        session.Delete(entity);
                    }
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

        public T Get(Guid uid)
        {
            var session = NHibernateHelper.GetCurrentSession();
            return session.Load<T>(uid);
        }

        protected int GetRowsCount()
        {
            var session = NHibernateHelper.GetCurrentSession();

            return session.QueryOver<T>().List().Count;
        }

        public void Update(T entity)
        {
            var session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }
    }
}