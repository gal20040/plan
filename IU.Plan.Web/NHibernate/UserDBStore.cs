using IU.Plan.Core.Impl;
using IU.Plan.Core.Models;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.Plan.Web.NHibernate
{
    /// <summary>
    /// Хранилище пользователей <see cref="User"/>
    /// </summary>
    public class UserDBStore : BaseDBStore<User>, IUserStore
    {
        public override IEnumerable<User> Entities =>
            base.Entities.Where(ent => ent.Status == UserStatus.Active);

        public override bool Delete(Guid uid)
        {
            var result = false;
            var evt = Get(uid);
            if (evt != null)
            {
                evt.Status = UserStatus.Deleted;
                UpdateByGuid(evt);
                result = true;
            }

            return result;
        }

        public User GetByName(string username)
        {
            var session = NHibernateHelper.GetCurrentSession();

            return session.CreateCriteria<User>()
                .Add(Restrictions.Eq(nameof(User.Status), UserStatus.Active))
                .Add(Restrictions.Eq(nameof(User.Email), username))
                .UniqueResult<User>();
        }
    }
}