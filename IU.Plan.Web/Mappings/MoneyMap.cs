using FluentNHibernate.Mapping;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class MoneyMap : ClassMap<Money>
    {
        public MoneyMap()
        {
            Id(self => self.Guid);
            Map(self => self.Currency);
            Map(self => self.Value);
        }
    }
}