using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

//TODO: Кириллица! +
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

		private byte _age;

		/// <summary>
		/// Возраст
		/// </summary>
		public byte Age
		{
			get => _age;
			set
			{
				const string pattern = @"\D";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(value.ToString()) == true)
				{
					throw new ArgumentException("Возраст должен быть числом!");
				}
				const byte maximumValue = 122;
				const byte minimumValue = 0;
				if ((value > maximumValue) || (value <= minimumValue))
				{
					throw new ArgumentException("Возраст должен быть больше чем " +
						$"{minimumValue} и меньше либо равен {maximumValue}!");
				}
				_age = value;
			}
			
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
		public Person(string name, string surname, byte age, Gender gender)
		{
			Name = name;
			Surname = surname;
			Age = age;
			Gender = gender;
		}

        /// <summary>
        /// Конструктор со значениями по умолчанию
        /// </summary>
        public Person() : this("Неизвестно", "Неизвестно", 18, Gender.Male) {  }

		//TODO: В info + свойство +
		/// <summary>
		/// Данные о персоне
		/// </summary>
        public string Info
		{
			get => $"Имя: {Name} \tФамилия: {Surname} \tВозраст: {Age} \tПол: {GenderRus(Gender)}";
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
			if (letterRegex.IsMatch(expression.ToLower()) == true ||
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
		private static string GenderRus(Gender gender)
        {
			 return gender == Gender.Male
				? "Мужчина"
				: "Женщина";
		}
	}
}
