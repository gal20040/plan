using FluentNHibernate.Mapping;
using IU.Plan.Web.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class ActivityMap : SubclassMap<Activity>
    {
        public ActivityMap()
        {
            Map(self => self.PeopleAmount);
            HasOne(self => self.Budget).Cascade.All().Not.LazyLoad();
        }
    }
}