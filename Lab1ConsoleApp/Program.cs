﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
	internal class Program
	{
		/// <summary>
		/// Метод для вывода списка в консоль
		/// </summary>
		/// <param name="personList">Лист для вывода</param>
		static public void ListToConsole(PersonList personList)
		{
			//TODO: скобочки
			if (personList.Count() == 0) 
				Console.WriteLine("Список пуст!");
			for (int i = 0; i < personList.Count(); i++)
			{
				Console.WriteLine(personList[i].PersonToConsole());
			}
			Console.WriteLine();
		}
		static void Main(string[] args)
		{
			//a. Создайте программно два списка персон, 
			//в каждом из которых будет по три человека
			PersonList personListOne = new PersonList();
			PersonList personListTwo = new PersonList();
			for (int i = 0; i < 3; i++)
			{
				personListOne.PersonAdd(Randomizer.GetRandomPerson());
				personListTwo.PersonAdd(Randomizer.GetRandomPerson());
			}

			//b.Выведите содержимое каждого списка на экран с соответствующими 
			//подписями списков
			Console.WriteLine("Первый список персон");
			ListToConsole(personListOne);
			Console.WriteLine("Второй список персон");
			ListToConsole(personListTwo);
			Console.ReadKey();

			//c. Добавьте нового человека в первый список
			personListOne.PersonAdd(Randomizer.GetRandomPerson());
			Console.WriteLine("Добавлен новый человек в первый список");
			Console.WriteLine();
			Console.ReadKey();

			//d. Скопируйте второго человека из первого списка в конец второго списка.
			//Покажите, что один и тот же человек находится в обоих списках
			personListTwo.PersonAdd(personListOne.SearchFromIndex(1));
			Console.WriteLine("Второй человек из первого списка скопирован в конец " +
				"второго списка");
			Console.WriteLine();
			Console.WriteLine("Первый список персон");
			ListToConsole(personListOne);
			Console.WriteLine("Второй список персон");
			ListToConsole(personListTwo);
			Console.ReadKey();

			//e. Удалите второго человека из первого списка.
			//Покажите, что удаление человека из первого списка не привело
			//к уничтожению этого же человека во втором списке
			personListOne.PersonDeleteByIndex(1);
			Console.WriteLine("Второй человек из первого списка удален");
			Console.WriteLine();
			Console.WriteLine("Первый список персон");
			ListToConsole(personListOne);
			Console.WriteLine("Второй список персон");
			ListToConsole(personListTwo);
			Console.ReadKey();

			//f. Очистите второй список.
			personListTwo.Clear();
			Console.WriteLine("Второй список очищен");
			Console.WriteLine();
			Console.WriteLine("Второй список персон");
			ListToConsole(personListTwo);
			Console.ReadKey();

			
			//Блок для тестирования
			//
			//Person egor = new Person("егорка-ПОМИДОРка", "asdf", 12, Gender.Female);
			//Person ori = new Person("Ori", "asdf", 121, Gender.Male);
			//Console.WriteLine(egor.PersonToConsole());

			//PersonList testPersonList = new PersonList();
			//testPersonList.PersonAdd(egor);
			//testPersonList.PersonAdd(ori);
			//Console.WriteLine();
			//Console.Write("Введите имя для поиска: ");
			//foreach (int i in testPersonList.ReturnTheIndex(Console.ReadLine()))
			//{
			//	Console.WriteLine(i);
			//}
			//Console.WriteLine();

			//Console.Write("Введите имя для удаления: ");
			//testPersonList.PersonDeleteByName(Console.ReadLine());
			//ListToConsole(testPersonList);
		}
	}
}
