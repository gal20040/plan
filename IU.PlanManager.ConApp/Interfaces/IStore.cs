using System;
using System.Collections.Generic;

namespace IU.PlanManager.ConApp.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища сущностей
    /// </summary>
    public interface IStore<T> where T : class, IEntity //T обязательно должен быть классом, а не просто интерфейсом, и должен реализовывать IEntity
    {
        IEnumerable<T> Entities { get; }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Add(T entity);

        /// <summary>
        /// Получить сущность
        /// </summary>
        /// <param name="guid">Guid сущности</param>
        T Get(Guid guid);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        void UpdateByGuid(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="guid">Guid сущности</param>
        bool Delete(Guid guid);
    }
}