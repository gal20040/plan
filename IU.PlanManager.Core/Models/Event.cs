using IU.PlanManager.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace IU.PlanManager.Core.Models
{
    [Serializable]
    public class Event : IEntity
    {
        public Event() { }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="description">Описание</param>
        public Event(string title, string description) : this()
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("message", nameof(title)); //todo добавить message
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("message", nameof(description)); //todo добавить message
            }

            Title = title;
            Description = description;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="description">Описание</param>
        /// <param name="startDateTime">Начало события</param>
        public Event(string title, string description, DateTime? startDateTime) : this(title, description)
        {
            StartDateTime = startDateTime;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="description">Описание</param>
        /// <param name="startDateTime">Начало события</param>
        /// <param name="endDateTime">Окончание события</param>
        public Event(string title, string description, DateTime? startDateTime, DateTime? endDateTime) : this(title, description, startDateTime)
        {
            if (startDateTime == null && endDateTime != null)
            {
                throw new ArgumentNullException(nameof(startDateTime), "message"); //todo добавить message
            }

            EndDateTime = endDateTime;
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="description">Описание</param>
        /// <param name="startDateTime">Начало события</param>
        /// <param name="endDateTime">Окончание события</param>
        public Event(string title, string description, DateTime? startDateTime, DateTime? endDateTime, string place) : this(title, description, startDateTime, endDateTime)
        {
            Place = place;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [Key]
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

        /// <summary>
        /// Место
        /// </summary>
        public override string ToString()
        {
            return $"Guid:\t\t{Guid}\n" +
                   $"Title:\t\t{Title}\n" +
                   $"Description:\t{Description}\n" +
                   $"Place:\t\t{Place}\n" +
                   $"StartDateTime:\t{StartDateTime}\n" +
                   $"EndDateTime:\t{EndDateTime}";
        }
    }
}