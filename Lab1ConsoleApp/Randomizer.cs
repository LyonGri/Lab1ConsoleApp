﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
    class Randomizer
    {
        //Объект генерации
		//
        private static Random RealRnd = new Random(DateTime.Now.Second);

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
			string[] femaleNames = new string[10] { "Maria", "Lydia", "Meghan",
				"Gloria", "Dixie", "Rita", "Kelley", "Wilma", "Silvia", "Lee" };
			string[] surnames = new string[10] { "Jones", "Miller", "Daniels",
				"Gibbs", "Sanders", "Potter", "Rhodes", "Lamb", "Sims", "Jordan" };

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


			//на основе получнных данных получаем объект Person
			Person RandomPerson = new Person(name, surname, age, gender);
			return RandomPerson;

		}

	}
}
