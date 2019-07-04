using System;

namespace IU.PlanManager.ConApp.Interfaces
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        Guid Guid { get; set; }
    }
}