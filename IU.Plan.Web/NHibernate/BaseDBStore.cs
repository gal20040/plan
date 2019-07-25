using IU.Plan.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace IU.Plan.Web.NHibernate
{
    /// <summary>
    /// Хранилище событий <see cref="IEntity"/>
    /// </summary>
    public class BaseDBStore<T> : IStore<T> where T : class, IEntity
    {
        private string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\{0}.json";

        public BaseDBStore()
        {
            if (GetRowsCount() == 0)
            {
                Init();
            }
        }

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
                        result = true;
                    }
                    tx.Commit();
                }
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

        public int GetRowsCount()
        {
            var session = NHibernateHelper.GetCurrentSession();

            return session.QueryOver<T>().List().Count;
        }

        protected virtual void Init()
        {
            fileName = string.Format(fileName, typeof(T).Name.ToLower());
            if (File.Exists(fileName))
            {
                var file = File.ReadAllText(fileName);
                var entities = JsonConvert.DeserializeObject<T[]>(file);
                foreach (var entity in entities)
                {
                    SaveByGuid(entity);
                }
            }
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

        public void SaveByGuid(T entity)
        {
            var session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(entity);
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