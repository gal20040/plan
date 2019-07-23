using IU.Plan.Core.Interfaces;
using IU.Plan.Core.Models;
using System;

namespace IU.Plan.Web.Extensions
{
    /// <summary>
    /// Мероприятие
    /// </summary>
    public class Activity : Event
    {
        /// <summary>
        /// Бюджет
        /// </summary>
        public virtual Money Budget { get; set; }

        /// <summary>
        /// Количество участников
        /// </summary>
        public virtual int PeopleAmount { get; set; }
    }

    /// <summary>
    /// Деньги
    /// </summary>
    public class Money : IEntity
    {
        /// <inheritdoc/>
        public virtual Guid Guid { get; set; }

        /// <summary>
        /// Мероприятие
        /// </summary>
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public virtual decimal Value { get; set; }
    }

    /// <summary>
    /// Валюта
    /// </summary>
    public enum Currency
    {
        RUB,
        EUR,
        USD,
        GBP,
        CNY
    }
}