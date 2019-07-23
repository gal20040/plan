using IU.Plan.Core.Interfaces;
using IU.Plan.Core.Models;

namespace IU.Plan.Core.Impl
{
    public interface IUserStore : IStore<User>
    {
        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        User GetByName(string userName);
    }
}