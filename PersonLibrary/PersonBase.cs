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
public enum Gender
{
	Male,
	Female
}

namespace PersonLibrary
{
	/// <summary>
	/// Описывает person
	/// </summary>
	public abstract class PersonBase
	{
		private string _name;

		/// <summary>
		/// Имя
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				_name = ValidateName(value);
			}
		}

		private string _surname;

		/// <summary>
		/// Фамилия
		/// </summary>
		public string Surname
		{
			get => _surname;
			set
			{
				_surname = ValidateName(value);
			}
		}

		/// <summary>
		/// Возраст
		/// </summary>
		public abstract byte Age
		{
			get;
			set;
		}

		private Gender _gender;

		/// <summary>
		/// Пол
		/// </summary>
		public Gender Gender
		{
			get => _gender;
			set
			{
				_gender = value;
			}
		}

		/// <summary>
		/// Конструктор класса Person
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="surname">Фамилия</param>
		/// <param name="age">Возраст</param>
		/// <param name="gender">Пол</param>
		public PersonBase(string name, string surname, byte age, Gender gender)
		{
			Name = name;
			Surname = surname;
			Age = age;
			Gender = gender;
		}


		/// <summary>
		/// Данные о персоне
		/// </summary>
		public virtual string Info
		{
			get
			{
				return $"Имя: {Name}\n" +
					$"Фамилия: {Surname}\n" +
					$"Возраст: {EndOfAgeInWords(Age)}\n" +
					$"Пол: {GenderRus(Gender)}\n";
			}
		}


		/// <summary>
		/// Проверка и форматирование имени и фамилии
		/// </summary>
		/// <param name="expression">Строка для проверки</param>
		/// <returns>Проверенная строка отформатированная в соответствии с правописанием</returns>
		private static string ValidateName(string expression)
		{
			if (expression == "" || expression == null)
			{
				throw new ArgumentException("Это поле не должно быть пустым!");
			}
			const string letterPattern = @"[^а-я^ё^А-Я^Ё^-]";
			const string hyphenPattern = @"-";
			Regex letterRegex = new Regex(letterPattern);
			Regex hyphenRegex = new Regex(hyphenPattern);
			if (letterRegex.IsMatch(expression.ToLower()) ||
				hyphenRegex.Matches(expression.ToLower()).Count > 1)
			{
				throw new ArgumentException("Поле заполнено некорректно.");
			}
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(expression.ToLower());
		}

		/// <summary>
		/// Преобразование пола в русский язык
		/// </summary>
		/// <param name="gender">Gender перосоны</param>
		/// <returns>Пол на русском языке</returns>
		protected static string GenderRus(Gender gender)
		{
			return gender == Gender.Male
			   ? "Мужчина"
			   : "Женщина";
		}

		/// <summary>
		/// Метод для добавления к возрасту слов
		/// </summary>
		/// <param name="age">Возраст</param>
		/// <returns></returns>
		protected static string EndOfAgeInWords(byte age)
		{
			string outputAge = $"{age}";
			//тут switch не подходит, так как оба if'а надо выполнить если условия выполняются
			//
			if (age > 100)
			{
				age = Convert.ToByte(age % 100);
			}
			if (age >= 10 && age <= 20)
            {
				return outputAge + " лет";
			}
			switch (age%10)
            {
				case 1:
                {
					return outputAge +" год";
				}
				case 2:
				case 3:
				case 4:
				{
					return outputAge + " года";
				}
				default:
                {
					return outputAge + " лет";
                }
			}

		}

		/// <summary>
		/// Метод для проверки возраста
		/// </summary>
		/// <param name="value">Проверяемый возраст</param>
		/// <param name="minimumValue">Минимальный возраст</param>
		/// <param name="maximumValue">Максимальный возраст</param>
		protected static void ValidateAge(byte value, byte minimumValue, byte maximumValue)
		{
			const string pattern = @"\D";
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(value.ToString()))
			{
				throw new ArgumentException("Возраст должен быть числом!");
			}

			if ((value > maximumValue) || (value < minimumValue))
			{
				throw new ArgumentException("Возраст должен быть больше или равен " +
					$"{minimumValue} и меньше либо равен {maximumValue}!");
			}
		}

		/// <summary>
		/// Метод для проверки учреждения (работа/учеба)
		/// </summary>
		/// <param name="expression">Проверяемое выражение</param>
		protected static void ValidateInstitution(string expression)
		{
			const string letterPattern = @"[^а-я^ё^А-Я^Ё^№0-9' ]";
			Regex letterRegex = new Regex(letterPattern);
			if (letterRegex.IsMatch(expression))
			{
				throw new ArgumentException("Поле заполнено некорректно.");
			}
		}
	}
}
