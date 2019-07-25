using System.Collections.Generic;
using IU.PlanManager.ConApp.Models;

namespace IU.PlanManager.ConApp
{
    /// <summary>
    /// Интерфейс хранилища
    /// </summary>
    public interface IUserStore : IStore<User>
    {
        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        User GetByName(string username);
    }
}
