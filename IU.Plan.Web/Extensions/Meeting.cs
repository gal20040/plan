using IU.Plan.Core.Models;
using System.Collections.Generic;

namespace IU.Plan.Web.Extensions
{
    /// <summary>
    /// Встреча
    /// </summary>
    public class Meeting : Event
    {
        private ISet<Participant> _participants;

        /// <summary>
        /// Участники
        /// </summary>
        public virtual ISet<Participant> Participants
        {
            get
            {
                return _participants ?? (_participants = new HashSet<Participant>());
            }
            set { _participants = value; }
        }
    }
}