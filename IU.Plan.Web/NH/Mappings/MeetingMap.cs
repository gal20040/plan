using FluentNHibernate.Mapping;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class MeetingMap : SubclassMap<Meeting>
    {
        public MeetingMap()
        {
            HasManyToMany(x => x.Participants)
                .Cascade.SaveUpdate()
                .Table("Meeting_User");
        }
    }
}