using FluentNHibernate.Mapping;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Mappings
{
    public class TaskMap : SubclassMap<Task>
    {
        public TaskMap()
        {
            Map(act => act.Result);
            Map(act => act.PercentComplete);
        }
    }
}