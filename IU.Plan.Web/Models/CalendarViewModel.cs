using IU.Plan.Core.Models;
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
        /// Начало периода
        /// </summary>
        public DateTime BeginOfPeriod { get; set; }

        /// <summary>
        /// Конец периода
        /// </summary>
        public DateTime EndOfPeriod { get; set; }
    }
}