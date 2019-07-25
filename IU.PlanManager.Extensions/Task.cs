using IU.PlanManager.ConApp.Models;

namespace IU.PlanManager.Extensions
{
    /// <summary>
    /// Задача
    /// </summary>
    public class Task : Event
    {
        /// <summary>
        /// Результат
        /// </summary>
        public virtual string Result { get; set; }

        /// <summary>
        /// Процент выполнения
        /// </summary>
        public virtual double PercentComplete { get; set; }
    }
}
