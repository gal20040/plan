using System;

namespace IU.Plan.Web.Extensions
{
    public static class DayOfWeekExtension
    {
        /// <summary>
        /// Возвращает числовой код дня от 0 до 6
        /// Неделя начинается с Понедельника
        /// </summary>
        /// <param name="dayOfWeek">День недели</param>
        /// <returns></returns>
        public static int ToInt(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek == 0 ? 7 : (int)dayOfWeek - 1;
        }
    }
}