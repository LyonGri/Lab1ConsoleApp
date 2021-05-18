using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
	/// <summary>
	/// Описывает список персон
	/// </summary>
	public class PersonList : IEnumerable
	{
		/// <summary>
		/// Массив содержащий в себе список персон
		/// </summary>
		private PersonBase[] _persons;

		/// <summary>
		/// Описание абстракции списка содержащего объекты класса Person
		/// </summary>
		public PersonList()
		{
			_persons = new PersonBase[0];
		}

		/// <summary>
		/// Добавление новых Person в список
		/// </summary>
		/// <param name="person">Персона для добавления</param>
		public void PersonAdd(PersonBase person)
		{
			Array.Resize<PersonBase>(ref _persons, _persons.Length + 1);
			_persons[_persons.Length - 1] = person;
		}

		/// <summary>
		/// Удаление элемента по индексу
		/// </summary>
		/// <param name="indexToDelete">Индекс персоны для удаления</param>
		public void PersonDeleteByIndex(int indexToDelete)
		{
			if ((_persons.Length != 0) && (_persons.Length >= indexToDelete))
			{
				var output = new PersonBase[_persons.Length - 1];
				int counter = 0;
				for (int i = 0; i < _persons.Length; i++)
				{
					if (i == indexToDelete) continue;

					output[counter] = _persons[i];
					counter++;
				}
				_persons = output;
			}
		}

		/// <summary>
		/// Удаление элемента по имени или фамилии
		/// </summary>
		/// <param name="nameToDelete">Имя или фамилия персоны</param>
		public void DeletePersonByName(string nameToDelete)
		{
			if ((_persons.Length != 0) && (nameToDelete != null))
			{
				var output = new PersonBase[0];
				int counter = 0;
				for (int i = 0; i < _persons.Length; i++)
				{
					if (_persons[i].Name.ToLower() == nameToDelete.ToLower()
						|| _persons[i].Surname.ToLower() == nameToDelete.ToLower()) continue;

					Array.Resize<PersonBase>(ref output, output.Length + 1);
					output[counter] = _persons[i];
					counter++;
				}
				_persons = output;
			}
		}

		/// <summary>
		/// Поиск по индексу
		/// </summary>
		/// <param name="indexToSearch">Идекс для поиска</param>
		/// <returns>Значение соответствующее индексу</returns>
		public PersonBase SearchByIndex(int indexToSearch)
		{
			if (indexToSearch <= _persons.Length)
			{
				return _persons[indexToSearch];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Поиск индекса по запросу
		/// </summary>
		/// <param name="name">Имя для поиска</param>
		/// <returns>Массив индексов соответствующих запросу</returns>
		public int[] ReturnTheIndex(string name)
		{
			int[] indexes = new int[0];
			for (int i = 0; i < _persons.Length; i++)
			{
				if (_persons[i].Name.ToLower().IndexOf(name.ToLower()) > -1
					|| _persons[i].Surname.ToLower().IndexOf(name.ToLower()) > -1)
				{
					Array.Resize<int>(ref indexes, indexes.Length + 1);
					indexes[i] = i;
				}
			}
			return indexes;
		}

		/// <summary>
		/// Метод для очистки списка
		/// </summary>
		public void Clear()
		{
			Array.Clear(_persons, 0, _persons.Length);
			Array.Resize<PersonBase>(ref _persons, 0);
		}

		/// <summary>
		/// Количество элементов в списке
		/// </summary>
		public int Count
		{
			get => _persons.Length;
		}

		/// <summary>
		/// Индексатор
		/// </summary>
		/// <param name="index">Индекс</param>
		/// <returns>Индекс записи</returns>
		public PersonBase this[int index]
		{
			get
			{
				int maximumValue = _persons.Length;
				int minimumValue = 0;
				if ((index < minimumValue) || (index > maximumValue))
				{
					throw new ArgumentException($"{nameof(index)} Выход за допустимые пределы!");
				}
				return _persons[index];
			}
			private set
			{
				int minimumValue = 0;
				if (index < minimumValue)
				{
					if (((index < minimumValue)))
					{
						throw new ArgumentException($"{nameof(index)} Выход за допустимые пределы!");
					}
					_persons[index] = value;
				}
			}
		}


		/// <summary>
		/// Енумератор для ForEach
		/// </summary>
		/// <returns>Запись</returns>
		public IEnumerator GetEnumerator()
		{
			return _persons.GetEnumerator();
		}
	}
}
