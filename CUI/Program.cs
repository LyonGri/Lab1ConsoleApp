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
			int i = 1;
			foreach (PersonBase person in personList)
            {
				Console.WriteLine($"Запись {i}.");
				Console.WriteLine(person.Info);
				Console.WriteLine();
				i++;
            }
			//добавил возможность foreach, но i++ остался:)
			//for (int i = 0; i < personList.Count; i++)
			//{
			//	Console.WriteLine($"Запись {i + 1}:");
			//	Console.WriteLine(personList[i].Info);
			//	Console.WriteLine();
			//}
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
								Console.WriteLine("Введите данные о взрослом на русском языке");
								typeOfPerson = true;
								break;
							}
						case "2":
							{
								Console.WriteLine("Введите данные о ребенке на русском языке");
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

			PersonBase person = typeOfPerson
				? new Adult()
				: new Child();

			var validationPersonActions = new List<Tuple<string, Action>>()
			{
				//TODO: Дубли +
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
				)
			};

			var validationAdultActions = new List<Tuple<string, Action>>()
			{
				//TODO: Дубли +
				new Tuple<string, Action>
				(
					"Паспорт: ",
					() =>
					{
						((Adult)person).Passport = Console.ReadLine();
					}
				),
				new Tuple<string, Action>
				(
					"Супруг: ",
					() =>
					{
						((Adult)person).Spouse = Randomizer.GetRandomSpouse((Adult)person);
						Console.WriteLine("Супруг сгенерирован!");
					}
				),
				new Tuple<string, Action>
				(
					"Работа: ",
					() =>
					{
						((Adult)person).Job = Console.ReadLine();
					}
				),
			};

			var validationChildActions = new List<Tuple<string, Action>>()
			{
				//TODO: Дубли +
				new Tuple<string, Action>
				(
					"Мать: ",
					() =>
					{
						((Child)person).Mother = Randomizer.GetRandomAdult();
						Console.WriteLine("Мать сгенерирована!");
					}
				),
				new Tuple<string, Action>
				(
					"Отец: ",
					() =>
					{
						((Child)person).Father = Randomizer.GetRandomSpouse(((Child)person).Mother);
						Console.WriteLine("Отец сгенерирован!");
					}
				),
				new Tuple<string, Action>
				(
					"Школа/Детский сад: ",
					() =>
					{
						((Child)person).School = Console.ReadLine();
					}
				),
			};

			ActionForEach(validationPersonActions);

			switch (typeOfPerson)
			{
				case true:
				{
					ActionForEach(validationAdultActions);
					break;
				}
				case false:
				{
					ActionForEach(validationChildActions);
					break;
				}
			}
			return person;
		}

		/// <summary>
		/// Метод для выполнения всех записей в листе с делегатами
		/// </summary>
		private static void ActionForEach(List<Tuple<string, Action>> validationActions)
		{
			foreach (var actionItem in validationActions)
			{
				ValidateInput(actionItem.Item1, actionItem.Item2);
			}
		}

		/// <summary>
		/// Возвращает тип пирсоны: взрослый/ребенок
		/// </summary>
		/// <param name="person">Проверяемый человек</param>
		/// <returns></returns>
		static public string GetTypeOfPerson(PersonBase person)
		{
			return person is Adult
				? "Взрослый"
				: "Ребенок";
		}

		/// <summary>
		/// Выполнение особых методов для каждого ребенка и взрослого
		/// </summary>
		/// <param name="person">Для кого требуется выполнить метод</param>
		public static void ExecuteExclusiveMethod(PersonBase person)
        {
			Console.WriteLine();
			Console.WriteLine("Выполнение особго метода");
			Console.WriteLine();
			Console.Clear();
			
			switch (person)
            {
				case Adult:
                {
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine(((Adult)person).SignUpTinder());
					break;
                }
				case Child:
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(((Child)person).DiaryEntry());
					break;
				}
			}
			Console.ForegroundColor = ConsoleColor.White;

		}

		/// <summary>
		/// Тело программы
		/// </summary>
		internal static void Main()
		{
			//то что было по заданию
			var people = new PersonList();
			for (int i = 0; i < 7; i++)
			{
				people.PersonAdd(Randomizer.GetRandomPerson());
			}
			ListToConsole(people, "Описание людей списка:");
			Console.Write($"Тип четвертого человека в списке: " +
				$"{GetTypeOfPerson(people.SearchByIndex(3))}");
			Console.WriteLine();
			Console.WriteLine("Нажмите любую клавишу чтобы выполнить особый метод...");
			Console.ReadKey();
			ExecuteExclusiveMethod(people.SearchByIndex(3));


			//для проверки ввода 
			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Нажмите любую клавишу для свободного ввода...");
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
