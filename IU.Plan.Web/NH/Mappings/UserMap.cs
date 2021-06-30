using FluentNHibernate.Mapping;
using IU.PlanManager.Core.Models;

namespace IU.Plan.Web.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            //Id(user => user.Uid);
            Id(user => user.Email);
            Map(user => user.Name);
            Map(user => user.Photo);
            Map(user => user.Status);
            Map(user => user.Gender);
            Map(user => user.Birthday);
            Map(user => user.AllowInvites);
        }
    }
}