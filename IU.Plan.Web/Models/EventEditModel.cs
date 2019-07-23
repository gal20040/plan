using IU.Plan.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IU.Plan.Web.Models
{
    public class EventEditModel
    {
        public EventEditModel() { }

        public EventEditModel(Event evt)
        {
            if (evt == null)
            {
                return;
            }

            Guid = evt.Guid;
            Title = evt.Title;
            Description = evt.Description;
            StartDateTime = evt.StartDateTime;
            EndDateTime = evt.EndDateTime;
            Place = evt.Place;
        }

        public virtual Event GetEvent()
        {
            return new Event()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                StartDateTime = StartDateTime,
                EndDateTime = EndDateTime,
                Place = Place
            };
        }

        /// <inheritdoc/>
        [HiddenInput(DisplayValue = false)]
        public Guid Guid { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Display(Name = "Тема")]
        [Required(ErrorMessage = "Без темы ничего нельзя сделать")]
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Начало события
        /// </summary>
        [Display(Name = "с")]
        [Required(ErrorMessage = "Нам нужно знать, когда это произойдет")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// Окончание события
        /// </summary>
        [Display(Name = "по")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Место 
        /// </summary>
        [Display(Name = "Где")]
        public string Place { get; set; }
    }
}