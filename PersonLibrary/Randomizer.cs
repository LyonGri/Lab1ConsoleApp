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
		private static Random _realRnd = new Random(DateTime.Now.Second);

		/// <summary>
		/// Метод для генерация случайной персоны
		/// </summary>
		/// <returns>Экземпляр случайной персоны</returns>
		static public Person GetRandomPerson()
		{
			List<string> engMaleNames = new List<string>()
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
			List<string> engFemaleNames = new List<string>()
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
			List<string> engSurnames = new List<string>()
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
			List<string> rusMaleNames = new List<string>()
			{
				"Алексей",
				"Роман",
				"Виктор",
				"Тимофей",
				"Максим",
				"Дмитрий",
				"Юрий",
				"Кирилл",
				"Артём",
				"Иван"
			};
			List<string> rusFemaleNames = new List<string>()
			{
				"Мария",
				"Карина",
				"Юлия",
				"Яна",
				"Арина",
				"Марина",
				"Дарья",
				"Кира",
				"Евгения",
				"Надежда"
			};
			List<string> rusSurnames = new List<string>()
			{
				"Лис",
				"Миллер",
				"Смитт",
				"Этвуд",
				"Блэк",
				"Форд",
				"Король",
				"Вагнер",
				"Киш",
				"Кремер"
			};
			
			var gender = _realRnd.Next(1, 3) == 1 
				? Gender.Male 
				: Gender.Female;
			
			var name = gender == Gender.Male
				? rusMaleNames[_realRnd.Next(0, rusMaleNames.Count)]
				: rusFemaleNames[_realRnd.Next(0, rusFemaleNames.Count)];
			
			var surname = rusSurnames[_realRnd.Next(0, rusSurnames.Count)];
			var age = Convert.ToByte(_realRnd.Next(18, 59));
			return new Person(name, surname, age, gender);
		}

	}
}
