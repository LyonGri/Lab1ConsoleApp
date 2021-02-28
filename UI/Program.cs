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
			//TODO: скобочки +
			if (personList.Count == 0)
			{
				Console.WriteLine("The list is empty!");
			}
			for (int i = 0; i < personList.Count; i++)
			{
				Console.WriteLine(personList[i].PersonInfo());
			}
			Console.WriteLine();
		}
		/// <summary>
		/// Проверка корректности введенного имени либо фамилии
		/// </summary>
		/// <param name="line">Строка для вывода в консоли</param>
		/// <returns>Имя либо фамилию, если оно введено корректно</returns>
		private static string CheckInputName(string line)
		{
			try
			{
				Console.Write(line);
				return Person.ValidationName(Console.ReadLine());
			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message} Try again.");
				return CheckInputName(line);
			}
		}
		/// <summary>
		/// Проверка корректности ввода возраста
		/// </summary>
		/// <param name="line">Строка для вывода в консоли</param>
		/// <returns>Возраст, если он введен корректно</returns>
		private static byte CheckInputAge(string line)
		{
			try
			{
				Console.Write(line);
				return Person.ValidationAge(Byte.Parse(Console.ReadLine()));
			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message} Try again.");
				return CheckInputAge(line);
			}
		}

		/// <summary>
		/// Проверка корректности ввода пола
		/// </summary>
		/// <param name="line">Строка для вывода в консоли</param>
		/// <returns>Пол, если он введен корректно</returns>
		private static Gender CheckInputGender(string line)
		{
			try
			{
				Console.Write(line);
				switch (Console.ReadLine())
				{
					case "M":
						return Gender.Male;
					case "m":
						return Gender.Male;
					case "F":
						return Gender.Female;
					case "f":
						return Gender.Female;
					default:
						throw new ArgumentException("You need to choose 'M' or 'F'");
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine($"{exception.Message} Try again.");
				return CheckInputGender(line);
			}
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
			ListToConsole(personListOne, "First person list");
			ListToConsole(personListTwo,"Second person list");
			Console.ReadKey();

			//c. Добавьте нового человека в первый список
			personListOne.PersonAdd(Randomizer.GetRandomPerson());
			Console.WriteLine("Added a new person to the first list");
			Console.WriteLine();
			Console.ReadKey();

			//d. Скопируйте второго человека из первого списка в конец второго списка.
			//Покажите, что один и тот же человек находится в обоих списках
			personListTwo.PersonAdd(personListOne.SearchByIndex(1));
			Console.WriteLine("The second person from the first list was copied to the" +
				" end of the second list");
			Console.WriteLine();
			ListToConsole(personListOne, "First person list");
			ListToConsole(personListTwo, "Second person list");
			Console.ReadKey();

			//e. Удалите второго человека из первого списка.
			//Покажите, что удаление человека из первого списка не привело
			//к уничтожению этого же человека во втором списке
			personListOne.PersonDeleteByIndex(1);
			Console.WriteLine("The second person from the first list has been removed");
			Console.WriteLine();
			ListToConsole(personListOne, "First person list");
			ListToConsole(personListTwo, "Second person list");
			Console.ReadKey();

			//f. Очистите второй список.
			personListTwo.Clear();
			Console.WriteLine("Second person list is cleared");
			Console.WriteLine();
			ListToConsole(personListTwo, "Second person list");
			Console.ReadKey();

			Console.Write("Press any key to go to person entry...");
			Console.ReadKey();
			Console.Clear();
			while (true)
			{
				Console.WriteLine("Enter data about the person");
				Person tobradex = new Person(CheckInputName("Name: "), 
					CheckInputName("Surname: "), CheckInputAge("Age: "), 
					CheckInputGender("Gender (M/F): "));
				Console.WriteLine("Your person:");
				Console.WriteLine(tobradex.PersonInfo());
				Console.ReadKey();
			}
		}
	}
}
