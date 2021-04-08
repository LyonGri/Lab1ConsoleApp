using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
	//TODO: XML
	public class Adult : PersonBase
	{
		/// <summary>
		/// Минимальный возраст
		/// </summary>
		public const byte MinimumAge = 14;

		/// <summary>
		/// Максимальный возраст
		/// </summary>
		public const byte MaximumAge = 122;

		private string _passport;

		/// <summary>
		/// Пасспорт
		/// </summary>
		public string Passport
		{
			get => _passport;
			set
			{
				const string pattern = @"\D";
				Regex regex = new Regex(pattern);
				if (value.Length != 10 || regex.IsMatch(value.ToString()) == true)
				{
					throw new ArgumentException("Паспорт должен состоять их 10 цифр!");
				}
				_passport = value;
			}
		}

		private Adult _spouse;

		/// <summary>
		/// Супруг
		/// </summary>
		public Adult Spouse
		{
			get => _spouse;
			set
			{
				_spouse = value;
			}
		}

		private string _job;

		/// <summary>
		/// Место работы
		/// </summary>
		public string Job
		{
			get => _job;
			set
			{
				ValidateSharaga(value);
				_job = value;
			}
		}

		private byte _age;

		/// <summary>
		/// Возраст
		/// </summary>
		public override byte Age
		{
			get => _age;
			set
			{
				ValidateAge(value, MinimumAge, MaximumAge);
				_age = value;
			}
		}

		/// <summary>
		/// Конструктор класса Adult
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="surname">Фамилия</param>
		/// <param name="age">Возраст</param>
		/// <param name="gender">Пол</param>
		/// <param name="passport">Пасспорт</param>
		/// <param name="spouse">Супруг</param>
		/// <param name="job">Место работы</param>
		public Adult(string name, string surname, byte age, Gender gender, 
			string passport, Adult spouse, string job) : base(name, surname, age, gender)
		{
			Name = name;
			Surname = surname;
			Age = age;
			Gender = gender;
			Passport = passport;
			Spouse = spouse;
			Job = job;
		}

		/// <summary>
		/// Конструктор со значениями по умолчанию
		/// </summary>
		public Adult() : this("Неизвестно", "Неизвестно", 18, Gender.Male, "0000000000", null, null) { }

		/// <summary>
		/// Информация о взрослом
		/// </summary>
		public override string Info
		{
			get => $"Имя: {Name}\n" +
				$"Фамилия: {Surname}\n" +
				$"Возраст: {Age}\n" +
				$"Пол: {GenderRus(Gender)}\n" +
				$"Паспорт: {Passport}" +
				$"\nСупруг: {(Spouse != null ? $"{Spouse.Name} {Spouse.Surname}" : "Отсутствует")}" +
				$"\nМесто работы: {(((Job != null) && (Job != "")) ?$"{Job}" : "Без работы")}";
		}
	}
}
