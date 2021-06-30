﻿using IU.PlanManager.Core.Models;
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

            Uid = evt.Uid;
            Author = evt.Author;
            Title = evt.Title;
            Description = evt.Description;
            StartDate = evt.StartDate;
            EndDate = evt.EndDate;
            Place = evt.Place;
        }

        public virtual Event GetEvent()
        {
            return new Event()
            {
                Uid = Uid,
                Author = Author,
                Title = Title,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                Place = Place
            };
        }

        /// <inheritdoc/>
        [HiddenInput(DisplayValue = false)]
        public Guid Uid { get; set; }

        /// <summary>
        /// Автор события
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public User Author { get; set; }

        /// <summary>
        /// Имя автора события
        /// </summary>
        [Display(Name = "Автор события")]
        public string AuthorName
        {
            get { return Author.Name; }
        }

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
        /// Начало периода
        /// </summary>
        [Display(Name = "с")]
        [Required(ErrorMessage = "Нам нужно знать когда это произойдет")]
        [DataType(DataType.DateTime)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Окончание периода
        /// </summary>
        [Display(Name = "по")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Место 
        /// </summary>
        [Display(Name = "Где")]
        public string Place { get; set; }
    }
}