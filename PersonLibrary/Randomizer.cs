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
		//TODO:
		private static Random _realRnd = new Random(DateTime.Now.Second);

		private static List<string> _rusMaleNames = new List<string>()
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

		private static List<string> _rusFemaleNames = new List<string>()
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

		private static List<string> _rusSurnames = new List<string>()
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

		private static List<string> _jobPlace = new List<string>()
		{
			"ПАО 'Газпром'",
			"ПАО 'Лукойл'",
			"ОАО 'РЖД'",
			"ПАО 'Сбербанк'",
			"ОК 'РУСАЛ'",
			"Колхоз имени Ленина"
		};

		private static List<string> _schools = new List<string>()
		{
			"Лицей",
			"Гимназия",
			"Детский сад 'Газик'",
			"Школа №1",
			"Ясли",
		};

		/// <summary>
		/// Метод для генерация случайного взрослого или ребенка
		/// </summary>
		/// <returns>Экземпляр случайной персоны</returns>
		static public PersonBase GetRandomPerson()
		{
			if (_realRnd.Next(1, 3) == 1)
			{
				return GetRandomChild();
			}
			else
			{
				return GetRandomAdult();
			}
		}

		/// <summary>
		/// Метод для генерации случайного взрослого человека
		/// </summary>
		/// <returns>Экземпляр случайного взрослого</returns>
		static public Adult GetRandomAdult()
		{
			//TODO: Дубли
			var adult = new Adult();
			adult.Gender = _realRnd.Next(1, 3) == 1
				? Gender.Male
				: Gender.Female;
			adult.Name = adult.Gender == Gender.Male
				? _rusMaleNames[_realRnd.Next(0, _rusMaleNames.Count)]
				: _rusFemaleNames[_realRnd.Next(0, _rusFemaleNames.Count)];
			adult.Surname = _rusSurnames[_realRnd.Next(0, _rusSurnames.Count)];
			adult.Age = Convert.ToByte(_realRnd.Next(Adult.MinimumAge, Adult.MaximumAge));
			adult.Passport = GetPassport();
			adult.Job = _jobPlace[_realRnd.Next(0, _jobPlace.Count)];
			if (_realRnd.Next(1, 3) == 1)
			{
				adult.Spouse = GetRandomSpouse(adult);
			}
			return adult;
		}

		/// <summary>
		/// Метод для генерации супруга
		/// </summary>
		/// <param name="spouse">Взрослый для которого нужно сгенерировать супруга</param>
		/// <returns>Супруга</returns>
		static public Adult GetRandomAdult(Adult spouse)
		{
			//TODO: Дубли
			var adult = new Adult();
			adult.Gender = spouse.Gender == Gender.Male
				? Gender.Female
				: Gender.Male;
			adult.Name = adult.Gender == Gender.Male
				? _rusMaleNames[_realRnd.Next(0, _rusMaleNames.Count)]
				: _rusFemaleNames[_realRnd.Next(0, _rusFemaleNames.Count)];
			adult.Surname = spouse.Surname;
			adult.Age = Convert.ToByte(_realRnd.Next(Adult.MinimumAge, Adult.MaximumAge));
			adult.Passport = GetPassport();
			adult.Job = _jobPlace[_realRnd.Next(0, _jobPlace.Count)];
			adult.Spouse = spouse;
			return adult;
		}

		/// <summary>
		/// Генерация случайного ребенка
		/// </summary>
		/// <returns>Экземпляр случайного ребенка</returns>
		static public Child GetRandomChild()
		{
			//TODO: Дубли
			var child = new Child();
			child.Gender = _realRnd.Next(1, 3) == 1
				? Gender.Male
				: Gender.Female;
			child.Name = child.Gender == Gender.Male
				? _rusMaleNames[_realRnd.Next(0, _rusMaleNames.Count)]
				: _rusFemaleNames[_realRnd.Next(0, _rusFemaleNames.Count)];
			child.Age = Convert.ToByte(_realRnd.Next(Child.MinimumAge, Child.MaximumAge));
			var parent = GetRandomAdult();
			if (parent.Spouse != null)
			{
				if (parent.Gender == Gender.Male)
				{
					child.Father = parent;
					child.Mother = parent.Spouse;
				}
				else
				{
					child.Mother = parent;
					child.Father = parent.Spouse;
				}
			}
			else
			{
				if (parent.Gender == Gender.Male)
				{
					child.Father = parent;
				}
				else
				{
					child.Mother = parent;
				}
			}
			child.Surname = parent.Surname;
			child.School = _schools[_realRnd.Next(0, _schools.Count)];
			return child;
		}

		/// <summary>
		/// Генерация случайного партнера в зависимости от пола
		/// </summary>
		/// <param name="spouse">Adult для которого нужно сгенерировать персону</param>
		/// <returns>Партнера для созданной ранее персоны</returns>
		static private Adult GetRandomSpouse(Adult spouse)
		{
			//TODO: Дубли
			var gender = spouse.Gender == Gender.Male
				? Gender.Female
				: Gender.Male;
			var name = gender == Gender.Male
				? _rusMaleNames[_realRnd.Next(0, _rusMaleNames.Count)]
				: _rusFemaleNames[_realRnd.Next(0, _rusFemaleNames.Count)];
			var surname = spouse.Surname;
			var age = Convert.ToByte(_realRnd.Next(Adult.MinimumAge, Adult.MaximumAge));
			var passport = GetPassport();
			var job = _jobPlace[_realRnd.Next(0, _jobPlace.Count)];
			return new Adult(name, surname, age, gender, passport, spouse, job);
		}

		/// <summary>
		/// Генерация паспортных данных
		/// </summary>
		/// <returns>10 цифр в строковом типе</returns>
		static private string GetPassport()
		{
			string passport = "";
			for (int i = 0; i < 10; i++)
			{
				passport += _realRnd.Next(0, 10).ToString();
			}
			return passport;
		}
	}
}
