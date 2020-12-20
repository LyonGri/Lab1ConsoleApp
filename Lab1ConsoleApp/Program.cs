using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //a. Создайте программно два списка персон, в каждом из которых будет по три человека
            PersonList PersonListOne = new PersonList();
            PersonList PersonListTwo = new PersonList();
            for (int i = 0; i < 3; i++)
            {
                PersonListOne.PersonAdd(Person.GetRandomPerson());
                PersonListTwo.PersonAdd(Person.GetRandomPerson());
            }

            //b.Выведите содержимое каждого списка на экран с соответствующими подписями списков
            Console.WriteLine("Первый список персон");
            PersonListOne.ListToConsole();
            Console.WriteLine("Второй список персон");
            PersonListTwo.ListToConsole();
            Console.ReadKey();

            //c. Добавьте нового человека в первый список
            PersonListOne.PersonAdd(Person.GetRandomPerson());
            Console.WriteLine("Добавлен новый человек в первый список");
            Console.WriteLine();
            Console.ReadKey();

            //d. Скопируйте второго человека из первого списка в конец второго списка. Покажите, что один и тот же человек находится в обоих списках
            PersonListTwo.PersonAdd(PersonListOne.SearchFromIndex(1));
            Console.WriteLine("Второй человек из первого списка скопирован в конец второго списка");
            Console.WriteLine();
            Console.WriteLine("Первый список персон");
            PersonListOne.ListToConsole();
            Console.WriteLine("Второй список персон");
            PersonListTwo.ListToConsole();
            Console.ReadKey();

            //e. Удалите второго человека из первого списка. Покажите, что удаление человека из первого списка не привело к уничтожению этого же человека во втором списке
            PersonListOne.PersonDelete(1);
            Console.WriteLine("Второй человек из первого списка удален");
            Console.WriteLine();
            Console.WriteLine("Первый список персон");
            PersonListOne.ListToConsole();
            Console.WriteLine("Второй список персон");
            PersonListTwo.ListToConsole();
            Console.ReadKey();

            //f. Очистите второй список.
            PersonListTwo.Clear();
            Console.WriteLine("Второй список очищен");
            Console.WriteLine();
            Console.WriteLine("Второй список персон");
            PersonListTwo.ListToConsole();
            Console.ReadKey();



        }
    }
}
