using System;

namespace IU.PlanManager.ConApp.Models
{
    public class Event : IEntity
    {
        public Event()
        {
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Начало события
        /// </summary>
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// Окончание события
        /// </summary>
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        public string Place { get; set; }
    }
}
