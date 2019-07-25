using FluentNHibernate.Mapping;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class MoneyMap : ClassMap<Money>
    {
        public MoneyMap()
        {
            Id(self => self.Uid);
            Map(self => self.Currency);
            Map(self => self.Value);
            HasOne(self => self.Activity).Cascade.All().Constrained();
        }
    }
}