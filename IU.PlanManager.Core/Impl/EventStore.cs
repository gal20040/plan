using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.PlanManager.ConApp.Models
{
    /// <summary>
    /// Хранилище событий <see cref="Event"/>
    /// </summary>
    public class EventStore : IStore<Event>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public EventStore()
        {
            Events = new List<Event>();
        }

        /// <summary>
        /// Список событий
        /// </summary>
        private List<Event> Events { get; }

        public IEnumerable<Event> Entities => Events;

        /// <summary>
        /// Добавить событие
        /// </summary>
        /// <param name="evt">Событие</param>
        public void Add(Event evt)
        {
            if (evt != null)
            {
                Events.Add(evt);
            }
        }

        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="uid">ID события</param>
        public Event Get(Guid uid)
        {
            return Events.FirstOrDefault(evt => evt.Uid == uid);
        }

        /// <summary>
        /// Обновить событие
        /// </summary>
        /// <param name="evt">Событие</param>
        public void Update(Event evt)
        {
            Delete(evt.Uid);
            Add(evt);
        }

        /// <summary>
        /// Удалить событие
        /// </summary>
        /// <param name="evt">Событие</param>
        public void Delete(Guid uid)
        {
            var elem = Get(uid);
            if (elem != null)
            {
                Events.Remove(elem);
            }
        }

    }
}
