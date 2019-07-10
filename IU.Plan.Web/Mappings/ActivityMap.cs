using FluentNHibernate.Mapping;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class ActivityMap : SubclassMap<Activity>
    {
        public ActivityMap()
        {
            HasOne(self => self.Budget);
            Map(self => self.PeopleAmount);
        }
    }
}