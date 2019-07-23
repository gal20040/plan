//using IU.Plan.Core.Impl;
//using IU.Plan.Core.Interfaces;
//using IU.Plan.Core.Models;
//using System.Data.Entity;
//using System.Linq;

//namespace IU.Plan.Web.Models
//{
//    public class EventDbInitializer : DropCreateDatabaseAlways<EventContext>
//    {
//        protected override void Seed(EventContext db)
//        {
//            IStore<Event> eventStore = new EventFileStore();

//            if (eventStore.Entities.Count() >= 0)
//            {
//                foreach (var @event in eventStore.Entities)
//                {
//                    db.Events.Add(@event);
//                }
//            }

//            base.Seed(db);
//        }
//    }
//}