using System.Collections.Generic;
using IU.PlanManager.Extensions;

namespace IU.PlanManager.ConApp.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Participant : User
    {
        private ISet<Meeting> _meetings;

        /// <summary>
        /// Встречи
        /// </summary>
        public virtual ISet<Meeting> Meetings
        {
            get
            {
                return _meetings ?? (_meetings = new HashSet<Meeting>());
            }
            set { _meetings = value; }
        }
    }
}
