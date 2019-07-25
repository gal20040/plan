using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IU.PlanManager.ConApp.Models;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Models
{
    public class MeetingEditModel : EventEditModel
    {
        public MeetingEditModel()
        {
            Users = new HashSet<Participant>();
        }

        public MeetingEditModel(Meeting evt) : base(evt)
        {
            if (evt == null)
            {
                return;
            }

            Users = evt.Participants;
        }


        public new Meeting GetEvent()
        {
            return new Meeting()
            {
                Uid = Uid,
                Title = Title,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                Place = Place,
                Participants = Users
            };
        }

        /// <summary>
        /// Участники
        /// </summary>
        [Display(Name = "Участники")]
        public ISet<Participant> Users { get; set; }
    }
}