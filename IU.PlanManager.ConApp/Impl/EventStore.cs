using IU.PlanManager.ConApp.Interfaces;
using IU.PlanManager.ConApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.PlanManager.ConApp.Impl
{
    /// <summary>
    /// Хранилище событий <see cref="Event">
    /// </summary>
    public class EventStore : IStore<Event> //EventStore должен реализовать IStore именно для Event
    {
        private List<Event> Events { get; }

        /// <summary>
        /// Список событий <see cref="Event">
        /// </summary>
        public IEnumerable<Event> Entities => Events;

        /// <summary>
        /// ctor
        /// </summary>
        public EventStore()
        {
            Events = new List<Event>();
        }

        /// <summary>
        /// Добавить событие
        /// </summary>
        /// <param name="@event">Событие</param>
        public void Add(Event @event)
        {
            if (@event != null)
            {
                Events.Add(@event);
            }
        }

        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="guid">Guid события</param>
        public Event Get(Guid guid)
        {
            return Events.FirstOrDefault(@event => @event.Guid == guid);
        }

        /// <summary>
        /// Оновить событие
        /// </summary>
        /// <param name="@event">Событие</param>
        public void UpdateByGuid(Event @event)
        {
            Delete(@event.Guid);
            Add(@event);
        }

        /// <summary>
        /// Удалить событие
        /// </summary>
        /// <param name="guid">Событие</param>
        public bool Delete(Guid guid)
        {
            if (guid == null)
            {
                return false;
            }

            var @event = Get(guid);
            if (@event == null)
            {
                return false;
            }

            return Events.Remove(@event);
        }
    }
}