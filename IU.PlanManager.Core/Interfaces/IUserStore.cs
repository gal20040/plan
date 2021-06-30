using IU.PlanManager.Core.Models;

namespace IU.PlanManager.Core.Interfaces
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