using IU.Plan.Core.Models;
using System.Collections.Generic;

namespace IU.Plan.Web.NHibernate
{
    public interface IEventStore<T> where T : Event
    {
        IEnumerable<T> Find(string search);
    }
}