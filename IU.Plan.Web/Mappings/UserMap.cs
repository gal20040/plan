using FluentNHibernate.Mapping;
using IU.Plan.Core.Models;

namespace IU.Plan.Web.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(self => self.Name);
            Map(self => self.Photo);
            Map(self => self.Status);
            Map(self => self.Gender);
            Map(self => self.Birthday);
            Map(self => self.AllowInvites);
            Id(self => self.Email);
        }
    }
}