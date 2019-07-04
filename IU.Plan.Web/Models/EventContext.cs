using IU.PlanManager.Core.Models;
using System.Data.Entity;

namespace IU.Plan.Web.Models
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}