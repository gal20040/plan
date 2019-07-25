using System;

namespace IU.PlanManager.ConApp.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IEntity
    {
        /// <inheritdoc/>
        public virtual Guid Uid { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public virtual DateTime Birthday { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public virtual string Photo { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// Принимать приглашения
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
    /// Статус пользователя
    /// </summary>
    public enum UserStatus
    {
        Active,
        Deleted
    }

    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Неопределено
        /// </summary>
        Undefined,
        /// <summary>
        /// Мужской
        /// </summary>
        Man,
        /// <summary>
        /// Женский
        /// </summary>
        Woman,

    }
}
