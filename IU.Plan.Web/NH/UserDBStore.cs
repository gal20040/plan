using IU.PlanManager.Core.Interfaces;
using IU.PlanManager.Core.Models;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.Plan.Web.NH
{
    /// <summary>
    /// Хранилище пользователей <see cref="User"/>
    /// </summary>
    public class UserDBStore : BaseDBStore<User>, IUserStore
    {
        public UserDBStore()
        {
            if (GetRowsCount() == 0)
            {
                Init();
            }
        }

        private void Init()
        {
            Add(new User()
            {
                Name = "Artem",
                Status = UserStatus.Active,
                Gender = Gender.Male,
                AllowInvites = true,
                Email = "artem@gmail.com"
            });

            Add(new User()
            {
                Name = "Paul",
                Status = UserStatus.Active,
                Gender = Gender.Male,
                AllowInvites = true,
                Email = "paul@gmail.com"
            });

            Add(new User()
            {
                Name = "Helen",
                Status = UserStatus.Active,
                Gender = Gender.Female,
                AllowInvites = true,
                Email = "helen@gmail.com"
            });
        }

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