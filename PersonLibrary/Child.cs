using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
	//TODO: xml
	public class Child : PersonBase
	{
		/// <summary>
		/// Минимальный возраст
		/// </summary>
		public const byte MinimumAge = 0;
		/// <summary>
		/// Максимальный возраст
		/// </summary>
		public const byte MaximumAge = 14;

		private Adult _mother;

		/// <summary>
		/// Мать
		/// </summary>
		public Adult Mother
		{
			get => _mother;
			set
			{
				_mother = value;
			}
		}

		private Adult _father;

		/// <summary>
		/// Отец
		/// </summary>
		public Adult Father
		{
			get => _father;
			set
			{
				_father = value;
			}
		}

		private string _school;

		/// <summary>
		/// Школа
		/// </summary>
		public string School
		{
			get => _school;
			set
			{
				ValidateSharaga(value);
				_school = value;
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
		/// Конструтор класса Child
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="surname">Фамилия</param>
		/// <param name="age">Возраст</param>
		/// <param name="gender">Пол</param>
		/// <param name="mother">Мать</param>
		/// <param name="father">Отец</param>
		/// <param name="school">Школа или детский сад</param>
		public Child(string name, string surname, byte age, Gender gender, 
			Adult mother, Adult father, string school) : base(name, surname, age, gender)
		{
			Name = name;
			Surname = surname;
			Age = age;
			Gender = gender;
			Mother = mother;
			Father = father;
			School = school;
		}

		/// <summary>
		/// Конструктор со значениями по умолчанию
		/// </summary>
		public Child() : this("Неизвестно", "Неизвестно", 0, Gender.Male, null, null, null) { }

		/// <summary>
		/// Информация о ребенке
		/// </summary>
		public override string Info
		{
			//вынести переменные
			//TODO: RSDN
			get => $"Имя: {Name}\n" +
				$"Фамилия: {Surname}\n" +
				$"Возраст: {Age}\n" +
				$"Пол: {GenderRus(Gender)}\n" +
				$"Мать: {(Mother != null ? $"{Mother.Name} {Mother.Surname}" : "Матери нет\n")}" +
				$"Отец: {(Father != null ? $"{Father.Name} {Father.Surname}" : "Отца нет")}\n" +
				$"Детский сад/школа: {(((School != null) && (School != "")) ? $"{School}" : "Дома сидит")}";
		}

	}
}
