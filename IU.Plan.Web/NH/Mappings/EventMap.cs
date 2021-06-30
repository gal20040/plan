using FluentNHibernate.Mapping;
using IU.PlanManager.Core.Models;

namespace IU.Plan.Web.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(self => self.Uid);
            HasOne(self => self.Author);
            Map(self => self.Title);
            Map(self => self.Description).Length(4001);
            Map(self => self.StartDate).Nullable();
            Map(self => self.EndDate).Nullable();
            Map(self => self.Place);
            Map(self => self.LifeStatus);
        }
    }
}