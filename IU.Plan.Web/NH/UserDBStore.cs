using System;
using System.Collections.Generic;
using System.Linq;
using IU.PlanManager.ConApp;
using IU.PlanManager.ConApp.Models;
using NHibernate.Criterion;

namespace IU.Plan.Web.NH
{
    /// <summary>
    /// Хранилище пользователей <see cref="User"/>
    /// </summary>
    public class UserDBStore : BaseDBStore<User>, IUserStore
    {
        public override IEnumerable<User> Entities =>
            base.Entities.Where(ent => ent.Status == UserStatus.Active);

        public override void Delete(Guid uid)
        {
            var evt = Get(uid);
            if (evt != null)
            {
                evt.Status = UserStatus.Deleted;
                Update(evt);
            }
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