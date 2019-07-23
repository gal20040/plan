using IU.Plan.Core.Models;
using System;
using System.Linq;

namespace IU.Plan.Core.Impl
{
    public class UserFileStore : BaseFileStore<User>, IUserStore
    {
        /// <inheritdoc/>
        public User GetByName(string userName)
        {
            return Entities.FirstOrDefault(user => user.Status != UserStatus.Deleted && user.Name.Contains(userName));
        }

        /// <inheritdoc/>
        public override bool Delete(Guid guid)
        {
            var user = Get(guid);
            if (user != null)
            {
                user.Status = UserStatus.Deleted;
                UpdateByGuid(user);
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override void UpdateByGuid(User user)
        {
            Delete(user.Guid);
            Add(user);
        }

        /// <inheritdoc/>
        public override User Get(Guid guid)
        {
            var user = base.Get(guid);
            if (user != null && user.Status != UserStatus.Deleted)
            {
                return user;
            }

            return null;
        }
    }
}