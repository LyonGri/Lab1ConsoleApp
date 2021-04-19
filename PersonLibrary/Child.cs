using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
	//TODO: xml +
	/// <summary>
	/// Описывает ребенка
	/// </summary>
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
				ValidateInstitution(value);
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
		public Child() : this("Неизвестно", "Неизвестно", 0, Gender.Male, null, null, "") { }

		/// <summary>
		/// Информация о ребенке
		/// </summary>
		public override string Info
		{
			//TODO: RSDN +
			get
			{
				var motherInfo = Mother != null
					? $"{Mother.Name} {Mother.Surname}"
					: "Матери нет";
				var fatherInfo = Father != null
					? $"{Father.Name} {Father.Surname}"
					: "Отца нет";
				var schoolInfo = School != ""
					? $"{School}"
					: "Сидит дома с бабушкой";
				return  base.Info +
						$"Мать: {motherInfo}\n" +
						$"Отец: {fatherInfo}\n" +
						$"Детский сад/школа: {schoolInfo}";
			}
		}


		/// <summary>
		/// Запись в дневнике
		/// </summary>
		/// <returns>Строка с записью</returns>
		public string DiaryEntry()
		{
			var outputString = "*Сообщение в дневнике*\n";
			if (School != "")
			{
				if (Mother != null && Father == null)
				{
					outputString += $"Уважаемая {Mother.Name} {Mother.Surname}!";
				}
				if (Father != null && Mother == null)
				{
					outputString += $"Уважаемый {Father.Name} {Father.Surname}!";
				}
				if (Mother != null && Father != null)
				{
					if (Father.Surname == Mother.Surname)
                    {
					outputString += $"Уважаемые {Father.Name} " +
						$"и {Mother.Name} {Mother.Surname}!";
                    }
					else
                    {
						outputString += $"Уважаемые {Father.Name} {Father.Surname} " +
							$"и {Mother.Name} {Mother.Surname}!";
					}
				}
				if (Mother == null && Father == null)
				{
					outputString += $"Уважаемые опекуны!";
				}
				return outputString + $"\nАдминистрация уведомляет, что Вас вызывают к Директору!\n{School}.";
			}
			return outputString + "Школа не для меня, ухожу снимать TikTok.";
		}
	}
}
