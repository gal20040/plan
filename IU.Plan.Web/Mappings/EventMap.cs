using FluentNHibernate.Mapping;
using IU.Plan.Core.Models;

namespace IU.Plan.Web.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(self => self.Guid);
            Map(self => self.Title);
            Map(self => self.Description).Length(4001);
            Map(self => self.StartDateTime).Nullable();
            Map(self => self.EndDateTime).Nullable();
            Map(self => self.Place);
            Map(evt => evt.LifeStatus);
        }
    }
}