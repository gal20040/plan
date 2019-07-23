using IU.Plan.Web.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
                Guid = Guid,
                Title = Title,
                Description = Description,
                StartDateTime = StartDateTime,
                EndDateTime = EndDateTime,
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