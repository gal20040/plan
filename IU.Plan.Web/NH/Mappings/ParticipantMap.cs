using FluentNHibernate.Mapping;
using IU.PlanManager.ConApp.Models;

namespace IU.Plan.Web.Mappings
{
    public class ParticipantMap : SubclassMap<Participant>
    {
        public ParticipantMap()
        {
            HasManyToMany(x => x.Meetings)
                .Cascade.All()
                .Inverse().Table("Meeting_User");
        }
    }
}