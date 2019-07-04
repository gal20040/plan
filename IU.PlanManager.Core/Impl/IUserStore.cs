using IU.PlanManager.Core.Interfaces;
using IU.PlanManager.Core.Models;
using System.Collections.Generic;

namespace IU.PlanManager.Core.Impl
{
    public interface IUserStore : IStore<User>
    {
        /// <summary>
        /// Получить список юзеров по имени
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        IEnumerable<User> GetByName(string userName);
    }
}