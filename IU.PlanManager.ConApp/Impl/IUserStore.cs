using IU.PlanManager.ConApp.Interfaces;
using IU.PlanManager.ConApp.Models;
using System.Collections.Generic;

namespace IU.PlanManager.ConApp.Impl
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