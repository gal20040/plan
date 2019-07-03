using System;

namespace IU.PlanManager.ConApp
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        Guid Guid { get; set; }
    }
}