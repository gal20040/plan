using IU.PlanManager.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IU.PlanManager.Core.Impl
{
    /// <summary>
    /// Хранилище сущностей <see cref="IEntity"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseFileStore<T> : IStore<T> where T : class, IEntity
    {
        private string fileName = AppDomain.CurrentDomain.BaseDirectory + @"..\{0}.json";

        /// <summary>
        /// ctor
        /// </summary>
        public BaseFileStore()
        {
            entities = new List<T>();
            Init();
        }

        protected virtual void Init()
        {
            fileName = string.Format(fileName, typeof(T).Name.ToLower());
            if (File.Exists(fileName))
            {
                var file = File.ReadAllText(fileName);
                var entities = JsonConvert.DeserializeObject<T[]>(file);
                this.entities.AddRange(entities);
            }
        }

        protected virtual void Flush()
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(entities));
        }

        /// <summary>
        /// Список сущностей
        /// </summary>
        private List<T> entities { get; }

        public IEnumerable<T> Entities => entities;

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="ent">Сущность</param>
        public virtual void Add(T ent)
        {
            if (ent != null)
            {
                entities.Add(ent);

                Flush();
            }
        }

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="uid">ID сущности</param>
        public virtual T Get(Guid uid)
        {
            return entities.FirstOrDefault(ent => ent.Guid == uid);
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="ent">Сущность</param>
        public virtual void Update(T ent)
        {
            Delete(ent.Guid);
            Add(ent);
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="uid">ID сущности</param>
        /// <returns></returns>
        public virtual bool Delete(Guid uid)
        {
            if (uid == null)
            {
                return false;
            }

            var elem = Get(uid);
            if (elem == null)
            {
                return false;
            }
            entities.Remove(elem);
            Flush();
            return true;
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="ent">Сущность</param>
        public virtual void UpdateByGuid(T ent)
        {
            Delete(ent.Guid);
            Add(ent);
        }
    }




    /*/// <summary>
    /// Хранилище сущностей <see cref="IEntity"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseFileStore<T> : IStore<T> where T : class, IEntity
    {
        public string FileName { get; private set; } = "{0}.xml";

        public BaseFileStore()
        {
            Init();
        }

        protected virtual void Init()
        {
            FileName = string.Format(FileName, typeof(T).Name.ToLower());
        }

        public IEnumerable<T> Entities => XmlHelper.GetEntitiesFromXmlFile(FileName);

        public virtual void Add(T newEntity)
        {
            if (newEntity == null)
            {
                return;
            }

            IStore<T> EntityStore = GetEntityStoreFromXmlFile();

            EntityStore.Add(newEntity);

            XmlHelper.SaveToFile(EntityStore.Entities, FileName);
        }

        protected virtual IStore<T> GetEntityStoreFromXmlFile()
        {
            IStore<T> EntityStore = new EntityStore();
            foreach (var @Entity in XmlHelper.GetEntitiesFromXmlFile(FileName))
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

            IStore<T> EntityStore = GetEntityStoreFromXmlFile();

            if (!EntityStore.Delete(guid))
            {
                return false;
            }

            XmlHelper.SaveToFile(EntityStore.Entities, FileName);

            return true;
        }

        public virtual T Get(Guid guid)
        {
            IStore<T> EntityStore = GetEntityStoreFromXmlFile();

            return EntityStore.Entities.FirstOrDefault(@Entity => @Entity.Guid == guid);
        }

        public virtual void UpdateByGuid(T @Entity)
        {
            Delete(@Entity.Guid);
            Add(@Entity);
        }
    }*/
}