using IU.Plan.Core.Impl;
using IU.Plan.Core.Interfaces;
using IU.Plan.Core.Models;
using System;
using System.Linq;

namespace IU.Plan.ConApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStore<Event> eventStore = new EventFileStore();

            var doWhile = true;
            while (doWhile)
            {
                //todo добавить все варианты в коллекцию - использовать из неё
                Console.WriteLine("0. Clear screen");
                Console.WriteLine("1. Add event");
                Console.WriteLine("2. Show all events");
                //Console.WriteLine("3. Save events to XML");
                //Console.WriteLine("4. Get events from XML");
                Console.WriteLine("9. Exit");

                //Получить выбор юзера
                var userSelect = Console.ReadLine();

                switch (userSelect)
                {
                    case "0":
                        Console.Clear();
                        break;

                    case "1":
                        //если выбрано Добавить, просим ввести Title и прочее
                        //сохраняем в хранилище, пишем, что всё ок

                        GetInfoForNewEvent(out string title,
                                           out string description,
                                           out DateTime? startDateTime,
                                           out DateTime? endDateTime,
                                           out string place);


                        var newEvent = new Event(title, description, startDateTime, endDateTime, place);

                        if (newEvent != null)
                        {
                            eventStore.Add(newEvent);
                            Console.WriteLine("Added."); //todo обновить
                        }
                        else
                        {
                            Console.WriteLine("Smth wrong."); //todo обновить
                        }

                        break;

                    case "2":
                        //если выбрано Показать, то получаем все события из хранилища и показываем списком

                        Console.WriteLine();

                        if (eventStore.Entities.Count() == 0)
                        {
                            Console.WriteLine("###################");
                            Console.WriteLine("Event list is empty");
                            Console.WriteLine("###################");
                        }
                        else
                        {
                            Console.WriteLine("###################");
                            Console.WriteLine("List of all events:");
                            Console.WriteLine("###################");
                            foreach (var @event in eventStore.Entities)
                            {
                                Console.WriteLine(@event);
                                Console.WriteLine();
                                //todo доработать вывод
                            }

                            Console.WriteLine("End of event list");
                            Console.WriteLine("#################");
                        }

                        break;

                    //case "3":
                    //    XmlHelper.SaveToFile(eventStore.Entities, fileName);
                    //    eventStore = new EventFileStore();
                    //    break;
                    //case "4":
                    //    eventStore = new EventFileStore();
                    //    foreach (var @event in XmlHelper.GetEntitiesFromXmlFile(fileName))
                    //    {
                    //        eventStore.Add(@event);
                    //    }
                    //    break;
                    case "9":
                        doWhile = false;
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void GetInfoForNewEvent(out string title, out string description, out DateTime? startDateTime, out DateTime? endDateTime, out string place)
        {
            title = GetInputString("Add title:");
            description = GetInputString("Add description:");
            startDateTime = null;

            var dateTimeMessageTemplate = "Add {0} (press enter to leave empty date), e.g. 23.12.2019 22:40:24:";
            do
            {
                if (startDateTime != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("'StartDateTime' should be lesser than 'EndDateTime'.");
                }
                startDateTime = GetInputDateTime(string.Format(dateTimeMessageTemplate, "startDateTime"));
                endDateTime = null;
                if (startDateTime != null)
                {
                    endDateTime = GetInputDateTime(string.Format(dateTimeMessageTemplate, "endDateTime"));
                }
            } while (startDateTime != null && endDateTime != null
                  && startDateTime >= endDateTime);

            place = GetInputString("Add place:");
        }

        private static string GetInputString(string dataDemandString)
        {
            Console.WriteLine(dataDemandString);
            var input = string.Empty;

            do
            {
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private static DateTime? GetInputDateTime(string dataDemandString)
        {
            Console.WriteLine(dataDemandString);
            var input = string.Empty;
            DateTime dateTimeResult;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }
            } while (!DateTime.TryParse(input, out dateTimeResult));

            return dateTimeResult;
        }
    }
}
