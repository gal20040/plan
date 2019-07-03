using IU.PlanManager.ConApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace IU.PlanManager.ConApp.Helper
{
    public static class XmlHelper
    {
        private const string FILE_NAME = "events.xml";

        public static void SaveToFile(IEnumerable<Event> events)
        {
            var writer = new StreamWriter(FILE_NAME);
            try
            {
                WriteDataToXmlFile(events.ToList(), writer);
            }
            finally
            {
                writer.Close();
            }
        }

        private static void WriteDataToXmlFile(List<Event> events, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Event>)).Serialize(writer, events);
        }

        public static List<Event> GetEventsFromXmlFile()
        {
            var events = new List<Event>();
            var reader = new StreamReader(FILE_NAME);
            try
            {
                events = (List<Event>)new XmlSerializer(typeof(List<Event>)).Deserialize(reader);
            }
            finally
            {
                reader.Close();
            }

            return events;
        }
    }
}