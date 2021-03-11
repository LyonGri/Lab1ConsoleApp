using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PersonLibrary;

namespace UI
{
	/// <summary>
	/// Тело программы
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Метод для вывода списка в консоль
		/// </summary>
		/// <param name="personList">Лист для вывода</param>
		/// <param name="message">Заголовок списка</param>
		static public void ListToConsole(PersonList personList, string message)
		{
			Console.WriteLine(message);
			if (personList.Count == 0)
			{
				Console.WriteLine("Список пуст!");
			}
			for (int i = 0; i < personList.Count; i++)
			{
				Console.WriteLine(personList[i].Info);
			}
			Console.WriteLine();
		}

		//TODO +
		/// <summary>
		/// Метод для проверки ввода персоны
		/// </summary>
		/// <param name="outputMessage">Строка для вывода в консоль</param>
		/// <param name="validationAction">Делегат с заданием параметра</param>
		private static void ValidateInput(string outputMessage, Action validationAction)
		{
			while(true)
			{
				try
				{
					Console.Write(outputMessage);
					validationAction();
					return;
				}
				catch (Exception exception)
				{
					Console.WriteLine($"{exception.Message} Попробуйте снова.");
				}
			}
		}

		/// <summary>
		/// Метод для ввода персоны с клавиатуры
		/// </summary>
		/// <returns>Персона введенная с клавиатуры</returns>
		private static Person InputPerson()
		{
			Console.WriteLine("Введите данные о новой персоне на русском языке");
			Person person = new Person();
			var validationActions = new List<Tuple<string, Action>>()
			{
				new Tuple<string, Action>
				(
					"Имя: ", 
					() => 
					{
						person.Name = Console.ReadLine();
					}
				),
				new Tuple<string, Action>
				(
					"Фамилия: ", 
					() => 
					{
						person.Surname = Console.ReadLine();
					}
				),
				new Tuple<string, Action>
				(
					"Возраст: ", 
					() => 
					{
						person.Age = Byte.Parse(Console.ReadLine());
					}
				),
				new Tuple<string, Action>
				(
					"Пол (М/Ж): ", 
					() => 
					{
						switch (Console.ReadLine())
						{
							case "М":
							case "м":
							{
								person.Gender = Gender.Male;
								break;
							}
							case "Ж":
							case "ж":
							{
								person.Gender = Gender.Female;
								break;
							}
							default:
							{
								throw new ArgumentException("Вам нужно выбрать 'М' или 'Ж'");
							}
						}
					}
				),
			};

			foreach (var actionItem in validationActions)
			{
				ValidateInput(actionItem.Item1, actionItem.Item2);
			}
			return person;
		}

		/// <summary>
		/// Тело программы
		/// </summary>
		static void Main()
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
			ListToConsole(personListOne, "Первый список персон");
			ListToConsole(personListTwo, "Второй список персон");
			Console.ReadKey();

			//c. Добавьте нового человека в первый список
			personListOne.PersonAdd(Randomizer.GetRandomPerson());
			Console.WriteLine("Добавлена новая персона в первый список");
			Console.WriteLine();
			Console.ReadKey();

			//d. Скопируйте второго человека из первого списка в конец второго списка.
			//Покажите, что один и тот же человек находится в обоих списках
			personListTwo.PersonAdd(personListOne.SearchByIndex(1));
			Console.WriteLine("Вторая персона из первого списка скопирована" +
				" в конец второго списка");
			Console.WriteLine();
			ListToConsole(personListOne, "Первый список персон");
			ListToConsole(personListTwo, "Второй список персон");
			Console.ReadKey();

			//e. Удалите второго человека из первого списка.
			//Покажите, что удаление человека из первого списка не привело
			//к уничтожению этого же человека во втором списке
			personListOne.PersonDeleteByIndex(1);
			Console.WriteLine("Вторая персона из первого списка удалена");
			Console.WriteLine();
			ListToConsole(personListOne, "Первый список персон");
			ListToConsole(personListTwo, "Второй список персон");
			Console.ReadKey();

			//f. Очистите второй список.
			personListTwo.Clear();
			Console.WriteLine("Второй список персон очищен");
			Console.WriteLine();
			ListToConsole(personListTwo, "Второй список персон");
			Console.ReadKey();

			Console.Write("Нажмите любую клавишу чтобы продолжить...");
			Console.ReadKey();
			Console.Clear();
			while (true)
			{
				Person chelovek = InputPerson();
				Console.WriteLine("Ваша персона:");
				Console.WriteLine(chelovek.Info);
				Console.ReadKey();
			}
		}
	}
}
