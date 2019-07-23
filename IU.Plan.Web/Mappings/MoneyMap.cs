using FluentNHibernate.Mapping;
using IU.Plan.Web.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class MoneyMap : ClassMap<Money>
    {
        public MoneyMap()
        {
            Id(self => self.Guid);
            Map(self => self.Currency);
            Map(self => self.Value);
            HasOne(self => self.Activity).Cascade.All().Constrained();
        }
    }
}