﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
	/// <summary>
	/// Генератор случайностей
	/// </summary>
	static class Randomizer
	{
		//Объект генерации
		//
		private static Random _realRnd = new Random(DateTime.Now.Second);

		/// <summary>
		/// Метод для генерация случайной персоны
		/// </summary>
		/// <returns>Экземпляр случайной персоны</returns>
		static public Person GetRandomPerson()
		{
			//Пул имен и фамилий
			string[] maleNames = new string[10]
			{
				"Ayten",
				"Sanjay",
				"Luther",
				"Allen",
				"Dominic",
				"Brett",
				"Bradford",
				"Julian",
				"Kenny",
				"Sam"
			};
			string[] femaleNames = new string[10] 
			{ 
				"Maria", 
				"Lydia", 
				"Meghan",
				"Gloria", 
				"Dixie", 
				"Rita", 
				"Kelley", 
				"Wilma", 
				"Silvia", 
				"Lee" 
			};
			string[] surnames = new string[10] 
			{ 
				"Jones", 
				"Miller", 
				"Daniels",
				"Gibbs", 
				"Sanders", 
				"Potter", 
				"Rhodes", 
				"Lamb", 
				"Sims", 
				"Jordan" 
			};

			//Переменные в которых хранятся сгенерированные значения
			string name;
			Gender gender;

			//Генерация пола
			if (_realRnd.Next(1, 3) == 1) 
			{ 
				gender = Gender.Male; 
			}
			else 
			{ 
				gender = Gender.Female; 
			}

			//Имя генерируется в зависимости от пола
			if (gender == Gender.Male)
			{
				name = maleNames[_realRnd.Next(0, maleNames.Length)];
			}
			else
			{
				name = femaleNames[_realRnd.Next(0, 9)];
			}

			//Генерация фамилии
			string surname = surnames[_realRnd.Next(0, 9)];

			//Генерация возраста
			byte age = Convert.ToByte(_realRnd.Next(18, 59));


			//на основе получнных данных получаем объект Person
			return new Person(name, surname, age, gender);

		}

	}
}
