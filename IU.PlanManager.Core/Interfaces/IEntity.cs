using System;

namespace IU.Plan.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity
    {
        Guid Guid { get; set; }
    }
}