using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

/// <summary>
/// Гендерная идентичность
/// </summary>
public enum Gender : byte
{
	Male,
	Female
}

namespace Lab1ConsoleApp
{
	/// <summary>
	/// Класс Person
	/// </summary>
	public class Person
	{
		private string _name;

		/// <summary>
		/// Имя
		/// </summary>
		public string Name 
		{
			get => _name;
			private set
			{
				//сначала все символы приведятся к строчным
				//затем формируется 2 регулярных выражения
				//letterRegex отбирает все что не соответствет буквам и дефису
				//hyphenPattern служит для проверки количества дефисов
				//
				const string letterPattern = @"[^a-z^а-я^A-Z^А-Я^-]";
				const string hyphenPattern = @"-";
				Regex letterRegex = new Regex(letterPattern);
				Regex hyphenRegex = new Regex(hyphenPattern);
				if (letterRegex.IsMatch(value.ToLower()) == true ||
					hyphenRegex.Match(value.ToLower()).Length > 1)
				{
					throw new ArgumentException($"{nameof(Name)} incorrect!");
				}
				//Какая-то хитрая система с заглавными буквами
				//
				_name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
			}
		}

		private string _surname;

		/// <summary>
		/// Фамилия
		/// </summary>
		public string Surname
		{
			get => _surname;
			private set
			{
				const string letterPattern = @"[^a-z^а-я^A-Z^А-Я^-]";
				const string hyphenPattern = @"-";
				Regex letterRegex = new Regex(letterPattern);
				Regex hyphenRegex = new Regex(hyphenPattern);
				if (letterRegex.IsMatch(value.ToLower()) == true ||
					hyphenRegex.Match(value.ToLower()).Length > 1)
				{
					throw new ArgumentException($"{nameof(Name)} incorrect!");
				}
				_surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
			}
		}

		private byte _age;

		/// <summary>
		/// Возраст
		/// </summary>
		public byte Age
		{
			get => _age;
			private set
			{
				//Проверка на символы отличные от чисел (нет смысла, так как byte)
				//
				const string pattern = @"\D";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(value.ToString()) == true)
				{
					throw new ArgumentException($"{nameof(Age)} should be a number!");
				}
				//Проверка на нахождение возраста в допустимом диапазоне
				//
				const byte maximumValue = 122;
				const byte minimumValue = 0;
				if ((value >= maximumValue) || (value < minimumValue))
				{
					throw new ArgumentException($"{nameof(Age)} should be greater then " +
						$"{minimumValue} and less than {maximumValue}!");
				}
				_age = value;
			}
			
		}

		private Gender _gender;

		/// <summary>
		/// Пол
		/// </summary>
		public Gender Gender 
		{ get => _gender;
			private set
			{
				_gender = value;
			}
		}

		/// <summary>
		/// Конструктор класса
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="surname">Фамилия</param>
		/// <param name="age">Возраст</param>
		/// <param name="gender">Пол</param>
		public Person(string name, string surname, byte age, Gender gender)
		{
			Name = name;
			Surname = surname;
			Age = age;
			Gender = gender;
		}

		//Объект генерации
		private static Random RealRnd = new Random(DateTime.Now.Second);

		//Метод для генерация случайной персоны
		static public Person GetRandomPerson()
		{
			//Пул имен и фамилий
			string[] maleNames = new string[10] { "Ayten", "Sanjay", "Luther", "Allen", "Dominic", "Brett", "Bradford", "Julian", "Kenny", "Sam" };
			string[] femaleNames = new string[10] { "Maria", "Lydia", "Meghan", "Gloria", "Dixie", "Rita", "Kelley", "Wilma", "Silvia", "Lee" };
			string[] surnames = new string[10] { "Jones", "Miller", "Daniels", "Gibbs", "Sanders", "Potter", "Rhodes", "Lamb", "Sims", "Jordan" };

			//Переменные в которых хранятся сгенерированные значения
			string name;
			string surname;
			byte age;
			Gender gender;

			//Генерация пола
			if (RealRnd.Next(1, 3) == 1) { gender = Gender.Male; }
			else { gender = Gender.Female; }

			//Имя генерируется в зависимости от пола
			if (gender == Gender.Male) { name = maleNames[RealRnd.Next(0, 9)]; }
			else { name = femaleNames[RealRnd.Next(0, 9)]; }

			//Генерация фамилии
			surname = surnames[RealRnd.Next(0, 9)];

			//Генерация возраста
			age = Convert.ToByte(RealRnd.Next(18, 59));


			//на снове получнных данных получаем объект Person
			Person RandomPerson = new Person(name, surname, age, gender);
			return RandomPerson;

		}
				
		/// <summary>
		/// Метод вывода персоны на экран
		/// </summary>
		/// <param name="Person"></param>
		static public void PersonToConsole(Person Person)
		{
			Console.WriteLine("Name: {0}\tSur: {1}\tAge: {2}      Gender: {3}", Person.Name, Person.Surname, Person.Age, Person.Gender);
		}
				
		/// <summary>
		/// Метод чтения персоны с клавиатуры
		/// </summary>
		/// <returns>Экземпляр персоны введенной с клавиатуры</returns>
		static public Person PersonInsert()
		{
			Console.Write("Name: ");
			string Name = Console.ReadLine();
			Console.Write("Sur: ");
			string Surname = Console.ReadLine();
			Console.Write("Age: ");
			byte Age = Convert.ToByte(Console.ReadLine());
			Console.Write("Gender: ");
			var Gender = Enum.Parse(typeof(Gender), Console.ReadLine(), true);
			Person Person = new Person(Name, Surname, Age, (Gender)Gender);
			return Person;
		}
	}
}
