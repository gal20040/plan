using FluentNHibernate.Mapping;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(evt => evt.Uid);
            Map(evt => evt.Title);
            Map(evt => evt.Description).Length(4001);
            Map(evt => evt.StartDate).Nullable();
            Map(evt => evt.EndDate).Nullable();
            Map(evt => evt.Place);
            Map(evt => evt.LifeStatus);
        }
    }
}