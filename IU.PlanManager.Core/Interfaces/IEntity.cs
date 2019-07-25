using System;

namespace IU.PlanManager.ConApp
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid Uid { get; set; }
    }
}
