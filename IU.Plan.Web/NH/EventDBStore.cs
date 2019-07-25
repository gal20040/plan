using System;
using System.Collections.Generic;
using System.Linq;
using IU.PlanManager.ConApp.Models;
using NHibernate.Criterion;

namespace IU.Plan.Web.NH
{
    public interface IEventStore<T> where T : Event
    {
        IEnumerable<T> Find(string search);
    }

    /// <summary>
    /// Хранилище событий <see cref="Event"/>
    /// </summary>
    public class EventDBStore<T> : BaseDBStore<T>, IEventStore<T>
        where T : Event
    {
        public override IEnumerable<T> Entities =>
            base.Entities.Where(ent => ent.LifeStatus == EntityLifeStatus.Active);

        public override void Delete(Guid uid)
        {
            var evt = Get(uid);
            if (evt != null)
            {
                evt.LifeStatus = EntityLifeStatus.Deleted;
                Update(evt);
            }
        }

        public IEnumerable<T> Find(string search)
        {
            var session = NHibernateHelper.GetCurrentSession();
            return session.QueryOver<T>()
                .Where(entity => entity.LifeStatus == EntityLifeStatus.Active)
                .And(Restrictions.Or(
                        Restrictions.Like(nameof(Event.Title), search, MatchMode.Anywhere),
                        Restrictions.Like(nameof(Event.Description), search, MatchMode.Anywhere)))
                .List();
        }
    }
}