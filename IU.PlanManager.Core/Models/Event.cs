using System;
using System.Collections.Generic;

namespace IU.PlanManager.ConApp.Models
{
    /// <summary>
    /// Событие
    /// </summary>
    public class Event : IEntity
    {
        /// <summary>
        /// ctor
        /// </summary>
        public Event()
        {
        }

        /// <inheritdoc/>
        public virtual Guid Uid { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Начало периода
        /// </summary>
        public virtual DateTime? StartDate { get; set; }

        /// <summary>
        /// Окончание периода
        /// </summary>
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Место 
        /// </summary>
        public virtual string Place { get; set; }

        public override string ToString()
        {
            var fields = new List<string>() { StartDate?.ToShortDateString(), Title , Place};

            fields.RemoveAll(s => string.IsNullOrWhiteSpace(s));

            return string.Join(", ", fields);
        }

        public virtual EntityLifeStatus LifeStatus { get; set; }
    }


    /// <summary>
    /// Статус сущности
    /// </summary>
    public enum EntityLifeStatus
    {
        Active,
        Deleted
    }

}
