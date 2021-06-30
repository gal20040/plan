using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Models
{
    public class ActivityEditModel : EventEditModel
    {
        public ActivityEditModel() {}

        public ActivityEditModel(Activity evt) : base(evt)
        {
            if (evt == null)
            {
                return;
            }

            Budget = evt.Budget;
            if (Budget != null)
            {
                BudgetUid = Budget.Uid;
            }
            PeopleAmount = evt.PeopleAmount;
        }

        public new Activity GetEvent()
        {
            var budget = Budget;
            budget.Uid = BudgetUid;

            var activity = new Activity()
            {
                Uid = Uid,
                Author = Author,
                Title = Title,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                Place = Place,
                Budget = budget,
                PeopleAmount = PeopleAmount
            };
            budget.Activity = activity;

            return activity;
        }

        [HiddenInput(DisplayValue = false)]
        public Guid BudgetUid { get; set; }

        /// <summary>
        /// Бюджет
        /// </summary>
        [Display(Name = "Бюджет")]
        public Money Budget { get; set; }

        /// <summary>
        /// Количество участников
        /// </summary>
        [Display(Name = "Количество участников")]
        public int PeopleAmount { get; set; }
    }
}