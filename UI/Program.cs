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
				Console.WriteLine($"Запись {i + 1}:");
				Console.WriteLine(personList[i].Info);
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Метод для проверки ввода персоны
		/// </summary>
		/// <param name="outputMessage">Строка для вывода в консоль</param>
		/// <param name="validationAction">Делегат с заданием параметра</param>
		private static void ValidateInput(string outputMessage, Action validationAction)
		{
			while (true)
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
		private static PersonBase InputSelection()
		{

			Console.WriteLine("Введите данные о новой персоне на русском языке");
			//true - Adult; false Child
			bool typeOfPerson = true;
			var typeOfPersonDefinition = new Tuple<string, Action>
			(
				"Для ввода взрослого введите '1', для ввода ребенка введите '2': ",
				() =>
				{
					switch (Console.ReadLine())
					{
						case "1":
							{
								typeOfPerson = true;
								break;
							}
						case "2":
							{
								typeOfPerson = false;
								break;
							}
						default:
							{
								throw new ArgumentException("Вам нужно выбрать 1 или 2");
							}
					}
				}
			);
			ValidateInput(typeOfPersonDefinition.Item1, typeOfPersonDefinition.Item2);

			//такая конструкция не заработала:(
			//PersonBase person = typeOfPerson
			//	? new Adult()
			//	: new Child();

			//var person = new Adult();
			if (typeOfPerson)
			{
				return InputAdult();
			}
			else
			{
				return InputChild();
			}
		}

		/// <summary>
		/// Метод для ввода взрослого с клавиатуры
		/// </summary>
		/// <returns>Взрослый введенный с клавиатуры</returns>
		private static Adult InputAdult()
		{
			Console.WriteLine("Введите данные о взрослом на русском языке");
			var person = new Adult();

			var validationAdultActions = new List<Tuple<string, Action>>()
			{
				//TODO: Дубли
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
				new Tuple<string, Action>
				(
					"Паспорт: ",
					() =>
					{
						person.Passport = Console.ReadLine();
					}
				),
				new Tuple<string, Action>
				(
					"Супруг: ",
					() =>
					{
						person.Spouse = Randomizer.GetRandomSpouse(person);
						Console.WriteLine("Супруг сгенерирован!");
					}
				),
				new Tuple<string, Action>
				(
					"Работа: ",
					() =>
					{
						person.Job = Console.ReadLine();
					}
				),
			};
			foreach (var actionItem in validationAdultActions)
			{
				ValidateInput(actionItem.Item1, actionItem.Item2);
			}
			return person;
		}

		/// <summary>
		/// Метод для ввода ребенка с клавиатуры
		/// </summary>
		/// <returns>Ребенок введенный с клавиатуры</returns>
		private static Child InputChild()
		{
			Console.WriteLine("Введите данные о ребенке на русском языке");
			var person = new Child();

			var validationAdultActions = new List<Tuple<string, Action>>()
			{
				//TODO: Дубли
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
				new Tuple<string, Action>
				(
					"Мать: ",
					() =>
					{
						person.Mother = Randomizer.GetRandomAdult();
						Console.WriteLine("Мать сгенерирована!");
					}
				),
				new Tuple<string, Action>
				(
					"Отец: ",
					() =>
					{
						person.Father = Randomizer.GetRandomSpouse(person.Mother);
						Console.WriteLine("Отец сгенерирован!");
					}
				),
				new Tuple<string, Action>
				(
					"Школа/Детский сад: ",
					() =>
					{
						person.School = Console.ReadLine();
					}
				),
			};
			foreach (var actionItem in validationAdultActions)
			{
				ValidateInput(actionItem.Item1, actionItem.Item2);
			}
			return person;
		}

		/// <summary>
		/// Возвращает тип пирсоны: взрослый/ребенок
		/// </summary>
		/// <param name="person">Проверяемый человек</param>
		/// <returns></returns>
		static public string GetTypeofPerson(PersonBase person)
		{
			return person is Adult
				? "Взрослый"
				: "Ребенок";
		}

		/// <summary>
		/// Тело программы
		/// </summary>
		static void Main()
		{
			//то что было по заданию
			var people = new PersonList();
			for (int i = 0; i < 7; i++)
			{
				people.PersonAdd(Randomizer.GetRandomPerson());
			}
			ListToConsole(people, "Описание людей списка:");
			Console.Write($"Тип четвертого человека в списке: " +
				$"{GetTypeofPerson(people.SearchByIndex(3))}");


			//для проверки ввода 
			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
				Console.ReadKey();
				Console.Clear();
				var chelovek = InputSelection();
				Console.WriteLine("Ваша персона:");
				Console.WriteLine();
				Console.WriteLine(chelovek.Info);
			}
		}
	}
}
