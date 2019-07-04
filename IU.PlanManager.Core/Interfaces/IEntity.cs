using System;

namespace IU.PlanManager.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        Guid Guid { get; set; }
    }
}