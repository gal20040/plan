using FluentNHibernate.Mapping;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class ActivityMap : SubclassMap<Activity>
    {
        public ActivityMap()
        {
            Map(act => act.PeopleAmount);
            HasOne(self => self.Budget).Cascade.All().Not.LazyLoad();
        }
    }
}