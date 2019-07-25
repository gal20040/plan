using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IU.Plan.Web
{
    public static class DayOfWeekExtension
    {
        /// <summary>
        /// Возвращает числовой код дня от 1 до 7
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static int ToInt(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek == 0 ? 7 : (int)dayOfWeek;
        }
    }
}