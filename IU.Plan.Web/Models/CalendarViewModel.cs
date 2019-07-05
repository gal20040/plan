using IU.PlanManager.Core.Models;
using System;
using System.Collections.Generic;

namespace IU.Plan.Web.Models
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            Events = new List<Event>();
        }

        /// <summary>
        /// События
        /// </summary>
        public IEnumerable<Event> Events { get; set; }

        /// <summary>
        /// Количество строк
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Количество колонок
        /// </summary>
        public int ColCount { get; set; }

        /// <summary>
        /// Количество дней в периоде
        /// </summary>
        public DateTime LastDayOfPeriod { get; set; }
    }
}