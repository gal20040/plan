using IU.PlanManager.Core.Models;
using System.Collections.Generic;

namespace IU.Plan.Web.Models
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            Events = new List<Event>();
        }

        public IEnumerable<Event> Events { get; set; }
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public int Limit { get; set; }
    }
}