using System;
using System.Linq;
using IU.PlanManager.ConApp.Models;

namespace IU.PlanManager.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {

            IStore<Event> store = null;
            store = new EventFileStore();

            var goWork = true;

            while (goWork)
            {
                Console.WriteLine("1. Добавь событие");
                Console.WriteLine("2. Показать все события");

                // получить выбор пользователя
                var select = Console.ReadLine();
                switch (select)
                {
                    case "0":
                        {
                            Console.Clear();
                            break;
                        }
                    case "1":
                        {
                            // если выбрано Добавить
                            var evt = new Event();

                            // просим ввести title и дату
                            Console.WriteLine("Введите тему");
                            var line = Console.ReadLine();
                            evt.Title = line;

                            Console.WriteLine("Введите дату в dd-mm-yyyy");
                            DateTime date;
                            if(DateTime.TryParse(Console.ReadLine(), out date))
                            {
                                evt.StartDate = date;
                            }

                            // сохраняем в хранилище
                            store.Add(evt);

                            // пишем , что все хорошо
                            Console.Clear();
                            Console.WriteLine($"В хранилище {store.Entities.Count()}");

                            break;
                        }
                    case "2":
                        {
                            // если выбрано Показать
                            Console.WriteLine("События:");
                            // перебираем все значения из хранилища
                            foreach (var evt in store.Entities)
                            {
                                // выводим их на экран
                                Console.WriteLine($"{evt}");
                            }
                            Console.WriteLine("---");
                            Console.WriteLine();
                            break;
                        }
                    default:
                        break;
                }
            }

            Console.ReadKey();

        }
    }
}
