using IU.PlanManager.ConApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.PlanManager.ConApp.Impl
{
    public class UserFileStore : BaseFileStore<User>, IUserStore
    {
        /// <inheritdoc/>
        public IEnumerable<User> GetByName(string userName)
        {
            return Entities.Where(user => user.Status != Status.Deleted && user.Name.Contains(userName));
        }

        /// <inheritdoc/>
        public override bool Delete(Guid guid)
        {
            var user = Get(guid);
            if (user != null)
            {
                user.Status = Status.Deleted;
                UpdateByGuid(user);
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override User Get(Guid guid)
        {
            var user = base.Get(guid);
            if (user != null && user.Status != Status.Deleted)
            {
                return user;
            }

            return null;
        }
    }
}