using IU.PlanManager.ConApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IU.PlanManager.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IStore<Event> eventStore = new EventStore();

            while (true)
            {
                //todo добавить все варианты в коллекцию - использовать из неё
                Console.WriteLine("0. Clear screen");
                Console.WriteLine("1. Add event");
                Console.WriteLine("2. Show all events");
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
                        Console.WriteLine("Add title:");
                        var title = Console.ReadLine();

                        if (title == string.Empty)
                        {
                            return;
                        }

                        var newEvent = CreateEvent(title);

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

                        foreach (var @event in eventStore.Entities)
                        {
                            Console.WriteLine($"{@event.Guid} {@event.Title}");
                            Console.WriteLine();
                            //todo доработать вывод
                        }

                        break;

                    case "9":
                    default:
                        break;
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static Event CreateEvent(string title)
        {
            if (title == string.Empty)
            {
                return null;
            }

            return new Event
            {
                Title = title
            };
        }
    }
}