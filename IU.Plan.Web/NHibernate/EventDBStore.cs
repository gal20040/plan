using IU.Plan.Core.Models;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU.Plan.Web.NHibernate
{
    /// <summary>
    /// Хранилище событий <see cref="Event"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventDBStore<T> : BaseDBStore<T>, IEventStore<T> where T : Event
    {
        /// <inheritdoc/>
        public override IEnumerable<T> Entities =>
            base.Entities.Where(ent => ent.LifeStatus == EntityLifeStatus.Active);

        /// <inheritdoc/>
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
                .Where(entity => entity.LifeStatus == EntityLifeStatus.Active).
                And(Restrictions.Or(
                    Restrictions.Like(nameof(Event.Title), search, MatchMode.Anywhere),
                    Restrictions.Like(nameof(Event.Description), search, MatchMode.Anywhere)))
                .List();
        }
    }
}