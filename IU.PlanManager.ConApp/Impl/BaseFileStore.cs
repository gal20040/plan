using IU.PlanManager.ConApp.Helper;
using IU.PlanManager.ConApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.PlanManager.ConApp.Impl
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseFileStore<T> : IStore<T> where T : class, IEntity //todo
    {
        private string fileName = "c:\\{0}.xml";

        public IEnumerable<T> Entities => XmlHelper.GetEntitiesFromXmlFile(fileName);

        public virtual void Add(T newEntity)
        {
            if (newEntity == null)
            {
                return;
            }

            IStore<T> EntityStore = GetEntitysFromXmlFile();

            EntityStore.Add(newEntity);

            XmlHelper.SaveToFile(EntityStore.Entities, fileName);
        }

        protected virtual IStore<T> GetEntitysFromXmlFile()
        {
            IStore<T> EntityStore = new EntityStore();
            foreach (var @Entity in XmlHelper.GetEntitiesFromXmlFile(fileName))
            {
                EntityStore.Add(@Entity);
            }

            return EntityStore;
        }

        public virtual bool Delete(Guid guid)
        {
            if (guid == null)
            {
                return false;
            }

            IStore<T> EntityStore = GetEntitysFromXmlFile();

            if (!EntityStore.Delete(guid))
            {
                return false;
            }

            XmlHelper.SaveToFile(EntityStore.Entities, fileName);

            return true;
        }

        public virtual T Get(Guid guid)
        {
            IStore<T> EntityStore = GetEntitysFromXmlFile();

            return EntityStore.Entities.FirstOrDefault(@Entity => @Entity.Guid == guid);
        }

        public virtual void UpdateByGuid(T @Entity)
        {
            Delete(@Entity.Guid);
            Add(@Entity);
        }
    }
}