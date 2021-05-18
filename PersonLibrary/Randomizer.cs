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
		//TODO: +
		private static Random _random = new Random(DateTime.Now.Second);

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
			"Лицей имени Фенимора Купера",
			"Гимназия для альтернативно одаренных",
			"Детский сад 'Газик'",
			"Школа с уклоном",
			"Ясли 'Паровозик'",
		};

		/// <summary>
		/// Метод для генерация случайного взрослого или ребенка
		/// </summary>
		/// <returns>Экземпляр случайной персоны</returns>
		static public PersonBase GetRandomPerson()
		{
			if (_random.Next(1, 3) == 1)
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
			//TODO: Дубли +
			var adult = new Adult();
			adult.Gender = GetGender();
			GetBasicInformation(adult);
			adult.Surname = GetSurname();
			if (_random.Next(1, 3) == 1)
			{
				adult.Spouse = GetRandomSpouse(adult);
			}
			return adult;
		}

		/// <summary>
		/// Метод для генерации супруга
		/// </summary>
		/// <param name="spouse">Взрослый для которого нужно сгенерировать супруга</param>
		/// <returns>Супруг</returns>
		static public Adult GetRandomSpouse(Adult spouse)
		{
			//TODO: Дубли +
			var adult = new Adult();
			adult.Gender = spouse.Gender == Gender.Female
					? Gender.Male
					: Gender.Female; ;
			GetBasicInformation(adult);
			adult.Surname = spouse.Surname;
			adult.Spouse = spouse;
			return adult;
		}

		/// <summary>
		/// Генерация случайного ребенка
		/// </summary>
		/// <returns>Экземпляр случайного ребенка</returns>
		static public Child GetRandomChild()
		{
			//TODO: Дубли +
			var child = new Child();
			child.Gender = _random.Next(1, 3) == 1
				? Gender.Male
				: Gender.Female;
			GetBasicInformation(child);
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
			return child;
		}

		/// <summary>
		/// Сгенерировать имя в зависимости от пола
		/// </summary>
		/// <param name="gender">Пол</param>
		/// <returns>Имя</returns>
		static private string GetName(Gender gender)
        {
			return gender == Gender.Male
				? _rusMaleNames[_random.Next(0, _rusMaleNames.Count)]
				: _rusFemaleNames[_random.Next(0, _rusFemaleNames.Count)];
		}

		/// <summary>
		/// Сгенерировать пол
		/// </summary>
		/// <returns>Пол</returns>
		static private Gender GetGender()
		{
			return _random.Next(1, 3) == 1
					? Gender.Male
					: Gender.Female;
		}

		/// <summary>
		/// Сгенерировать фамилию
		/// </summary>
		/// <returns>Фамилия</returns>
		static private string GetSurname()
		{
			return  _rusSurnames[_random.Next(0, _rusSurnames.Count)];
		}

		/// <summary>
		/// Сгенерировать возраст
		/// </summary>
		/// <param name="minimumAge">Минимальный возраст</param>
		/// <param name="maximumAge">Максимальный возраст</param>
		/// <returns>Возраст</returns>
		static private byte GetAge(byte minimumAge, byte maximumAge)
		{
			return Convert.ToByte(_random.Next(minimumAge, maximumAge));
		}

		/// <summary>
		/// Получить место работы/учебы
		/// </summary>
		/// <param name="institutions"></param>
		/// <returns>Место работы/учебы</returns>
		static private string GetInstitution(List<string> institutions)
		{
			return institutions[_random.Next(0, institutions.Count)];
		}

		/// <summary>
		/// Генерация основной информации
		/// </summary>
		/// <param name="person">Персона для которой нужно сгенерировать информацию</param>
		static private void GetBasicInformation(PersonBase person)
		{
			person.Name = GetName(person.Gender);
			if (person is Adult)
            {
                ((Adult)person).Age = GetAge(Adult.MinimumAge, Adult.MaximumAge);
				((Adult)person).Passport = GetPassport();
				((Adult)person).Job = GetInstitution(_jobPlace);
            }
			else
			{
				((Child)person).Age = GetAge(Child.MinimumAge, Child.MaximumAge);
				((Child)person).School = GetInstitution(_schools);
			}
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
				passport += _random.Next(0, 10).ToString();
			}
			return passport;
		}
	}
}
