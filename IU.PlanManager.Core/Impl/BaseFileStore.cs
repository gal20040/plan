using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace IU.PlanManager.ConApp.Models
{
    /// <summary>
    /// Хранилище событий <see cref="IEntity"/>
    /// </summary>
    public class BaseFileStore<T> : IStore<T>
        where T : class, IEntity
    {
        private string fileName = "c:\\{0}.json";

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
        /// Список событий
        /// </summary>
        private List<T> entities { get; }

        public IEnumerable<T> Entities => entities;

        /// <summary>
        /// Добавить событие
        /// </summary>
        /// <param name="evt">Событие</param>
        public virtual void Add(T evt)
        {
            if (evt != null)
            {
                entities.Add(evt);

                Flush();
            }
        }

        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="uid">ID события</param>
        public virtual T Get(Guid uid)
        {
            return entities.FirstOrDefault(evt => evt.Uid == uid);
        }

        /// <summary>
        /// Обновить событие
        /// </summary>
        /// <param name="evt">Событие</param>
        public virtual void Update(T evt)
        {
            Delete(evt.Uid);
            Add(evt);
        }

        /// <summary>
        /// Удалить событие
        /// </summary>
        /// <param name="evt">Событие</param>
        public virtual void Delete(Guid uid)
        {
            var elem = Get(uid);
            if (elem != null)
            {
                entities.Remove(elem);
                Flush();
            }
        }

    }
}
