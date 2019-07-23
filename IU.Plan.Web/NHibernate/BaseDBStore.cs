using IU.Plan.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace IU.Plan.Web.NHibernate
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
            UpdateByGuid(entity);
        }

        public virtual bool Delete(Guid uid)
        {
            var result = false;
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
                result = true;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }

            return result;
        }

        public T Get(Guid uid)
        {
            var session = NHibernateHelper.GetCurrentSession();
            return session.Load<T>(uid);
        }

        public void UpdateByGuid(T entity)
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