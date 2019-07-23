using IU.Plan.Web.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IU.Plan.Web.Models
{
    public class ActivityEditModel : EventEditModel
    {
        public ActivityEditModel()
        {

        }

        public ActivityEditModel(Activity evt) : base(evt)
        {
            if (evt == null)
            {
                return;
            }

            Budget = evt.Budget;
            if (Budget != null)
            {
                BudgetUid = Budget.Guid;
            }
            PeopleAmount = evt.PeopleAmount;
        }


        public new Activity GetEvent()
        {
            var budget = Budget;
            budget.Guid = BudgetUid;

            var activity = new Activity()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                StartDateTime = StartDateTime,
                EndDateTime = EndDateTime,
                Place = Place,
                Budget = budget,
                PeopleAmount = PeopleAmount
            };
            budget.Activity = activity;

            return activity;
        }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Display(Name = "Бюджет")]
        public Money Budget { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Guid BudgetUid { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [Display(Name = "Количество людей")]
        public int PeopleAmount { get; set; }
    }
}