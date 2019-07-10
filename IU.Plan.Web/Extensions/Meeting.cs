using IU.PlanManager.Core.Models;
using System.Collections.Generic;

namespace IU.Plan.Web.Extensions
{
    /// <summary>
    /// Встреча
    /// </summary>
    public class Meeting : Event
    {
        /// <summary>
        /// Участники
        /// </summary>
        public virtual IEnumerable<User> Participants { get; set; }
    }
}