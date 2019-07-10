using FluentNHibernate.Mapping;
using IU.PlanManager.Core.Models;

namespace IU.Plan.Web.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(self => self.Guid);
            Map(self => self.Title);
            Map(self => self.Description);
            Map(self => self.StartDateTime);
            Map(self => self.EndDateTime);
            Map(self => self.Place);
        }
    }
}