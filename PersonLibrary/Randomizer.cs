using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
	/// <summary>
	/// Генератор случайностей
	/// </summary>
	public static class Randomizer
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
			List<string> maleNames = new List<string>()
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
			List<string> femaleNames = new List<string>()
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
			List<string> surnames = new List<string>()
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
				name = maleNames[_realRnd.Next(0, maleNames.Count)];
			}
			else
			{
				name = femaleNames[_realRnd.Next(0, femaleNames.Count)];
			}

			//Генерация фамилии
			string surname = surnames[_realRnd.Next(0, surnames.Count)];

			//Генерация возраста
			byte age = Convert.ToByte(_realRnd.Next(18, 59));


			//на основе получнных данных получаем объект Person
			return new Person(name, surname, age, gender);

		}

	}
}
