using IU.Plan.Core.Interfaces;
using System;

namespace IU.Plan.Core.Models
{
    public class User : IEntity
    {
        /// <inheritdoc/>
        public virtual Guid Guid { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public virtual string Birthday { get; set; }

        /// <summary>
        /// Фотография
        /// </summary>
        public virtual string Photo { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Принимать приглашение
        /// </summary>
        public virtual bool AllowInvites { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Статус пользователя
        /// </summary>
        public virtual UserStatus Status { get; set; }
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

    /// <summary>
    /// Статус пользователя
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Пользователь активен
        /// </summary>
        Active,
        /// <summary>
        /// Пользователь удалён
        /// </summary>
        Deleted
    }
}