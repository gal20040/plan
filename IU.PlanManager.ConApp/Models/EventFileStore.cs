using IU.PlanManager.ConApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.PlanManager.ConApp.Models
{
    public class EventFileStore : IStore<Event> //EventFileStore должен реализовать IStore именно для Event
    {
        public IEnumerable<Event> Entities => XmlHelper.GetEventsFromXmlFile();

        /// <summary>
        /// Добавить событие
        /// </summary>
        /// <param name="@event">Событие</param>
        public void Add(Event newEvent)
        {
            if (newEvent == null)
            {
                return;
            }

            IStore<Event> EventStore = GetEventsFromXmlFile();

            EventStore.Add(newEvent);

            XmlHelper.SaveToFile(EventStore.Entities);
        }

        private IStore<Event> GetEventsFromXmlFile()
        {
            IStore<Event> EventStore = new EventStore();
            foreach (var @event in XmlHelper.GetEventsFromXmlFile())
            {
                EventStore.Add(@event);
            }

            return EventStore;
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

            IStore<Event> EventStore = GetEventsFromXmlFile();

            if (!EventStore.Delete(guid))
            {
                return false;
            }

            XmlHelper.SaveToFile(EventStore.Entities);

            return true;
        }

        /// <summary>
        /// Получить событие
        /// </summary>
        /// <param name="guid">Guid события</param>
        public Event Get(Guid guid)
        {
            IStore<Event> EventStore = GetEventsFromXmlFile();

            return EventStore.Entities.FirstOrDefault(@event => @event.Guid == guid);
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
    }
}