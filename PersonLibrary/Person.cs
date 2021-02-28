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

namespace PersonLibrary
{
	/// <summary>
	/// Описывает person
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
				//TODO: Дубль +
				_name = ValidationName(value);
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
				//TODO: Дубль +
				_surname = ValidationName(value);
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
				_age = ValidationAge(value);
			}
			
		}

		private Gender _gender;

		/// <summary>
		/// Пол
		/// </summary>
		public Gender Gender 
		{ 
			get => _gender;
			private set
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
		public Person(string name, string surname, byte age, Gender gender)
		{
			Name = name;
			Surname = surname;
			Age = age;
			Gender = gender;
		}

		/// <summary>
		/// Метод вывода персоны 
		/// </summary>
		/// <param name="Person"></param>
		/// <returns>Персона в виде строки</returns>
		public string PersonInfo()
		{
			return "Name: " + Name + "\tSurname: " + Surname + "\tAge: " + Age + "\tGender: " + Gender;
		}

		/// <summary>
		/// Проверка и форматирование имени и фамилии
		/// </summary>
		/// <param name="expression">Строка для проверки</param>
		/// <returns>Проверенная строка отформатированная в соответствии с правописанием</returns>
		public static string ValidationName(string expression)
        {
			if (expression == "" || expression == null)
			{
				throw new ArgumentException("The field must not be empty!");
			}
			const string letterPattern = @"[^a-z^а-я^A-Z^А-Я^-]";
			const string hyphenPattern = @"-";
			Regex letterRegex = new Regex(letterPattern);
			Regex hyphenRegex = new Regex(hyphenPattern);
			if (letterRegex.IsMatch(expression.ToLower()) == true ||
				hyphenRegex.Matches(expression.ToLower()).Count > 1)
			{
				throw new ArgumentException("The field is filled in incorrectly.");
			}
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(expression.ToLower());
		}

		/// <summary>
		/// Проверка возраста
		/// </summary>
		/// <param name="expression">Переменная для проверки</param>
		/// <returns>Проверенный возраст</returns>
		public static byte ValidationAge(byte expression)
		{
			//этот метод реализован для удобства проверок извне
			//
			const string pattern = @"\D";
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(expression.ToString()) == true)
			{
				throw new ArgumentException($"{nameof(Age)} should be a number!");
			}
			const byte maximumValue = 122;
			const byte minimumValue = 0;
			if ((expression > maximumValue) || (expression <= minimumValue))
			{
				throw new ArgumentException($"{nameof(Age)} should be greater then " +
					$"{minimumValue} and less than {maximumValue}!");
			}
			return expression;
		}
	}
}
