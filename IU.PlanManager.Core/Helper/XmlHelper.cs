using IU.Plan.Core.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace IU.Plan.Core.Helper
{
    public static class XmlHelper
    {
        public static void SaveToFile(IEnumerable<IEntity> entities, string fileName)
        {
            var writer = new StreamWriter(fileName);
            try
            {
                WriteDataToXmlFile(entities.ToList(), writer);
            }
            finally
            {
                writer.Close();
            }
        }

        private static void WriteDataToXmlFile(List<IEntity> entities, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<IEntity>)).Serialize(writer, entities);
        }

        public static IEnumerable<IEntity> GetEntitiesFromXmlFile(string fileName)
        {
            var entities = new List<IEntity>();
            var reader = new StreamReader(fileName);
            try
            {
                entities = (List<IEntity>)new XmlSerializer(typeof(List<IEntity>)).Deserialize(reader);
            }
            finally
            {
                reader.Close();
            }

            return entities;
        }
    }
}