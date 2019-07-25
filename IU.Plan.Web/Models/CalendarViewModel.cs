using System;
using System.Collections.Generic;
using IU.PlanManager.ConApp.Models;

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
        /// Количество ячеек
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Количество колонок
        /// </summary>
        public int ColCount { get; set; }

        /// <summary>
        /// Количество строк
        /// </summary>
        public int RowCount
        {
            get
            {
                var totalCells = Limit + StartDay.DayOfWeek.ToInt();

                return (int)Math.Ceiling(totalCells * 1d / ColCount);
            }
        }

        /// <summary>
        /// С какого дня недели начинается месяц
        /// </summary>
        public DateTime StartDay { get; set; }
    }
}