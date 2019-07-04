using IU.PlanManager.ConApp.Interfaces;
using System;

namespace IU.PlanManager.ConApp.Models
{
    public class User : IEntity
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Принимать приглашение
        /// </summary>
        public bool AllowInvites { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
    }

    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Не определён
        /// </summary>
        Undefined,
        /// <summary>
        /// Женский
        /// </summary>
        Female,
        /// <summary>
        /// Мужской
        /// </summary>
        Male
    }
}