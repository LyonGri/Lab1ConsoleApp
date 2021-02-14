using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
	class PersonList
	{
		/// <summary>
		/// Массив содержащий в себе список персон
		/// </summary>
		private Person[] _persons;

		/// <summary>
		/// Описание абстракции списка содержащего объекты класса Person
		/// </summary>
		public PersonList()
		{
			_persons = new Person[0];
		}

		/// <summary>
		/// Добавление новых Person в список
		/// </summary>
		/// <param name="Person"></param>
		public void PersonAdd(Person person)
		{ 
			Array.Resize<Person>(ref _persons, _persons.Length + 1);
			_persons[_persons.Length - 1] = person;
		}

		/// <summary>
		/// Удаление элемента по индексу
		/// </summary>
		/// <param name="IndexToDelete"></param>
		/// <returns></returns>
		public void PersonDelete(int IndexToDelete)
		{
			// Проверки, что наш массив не пуст и что указанный индекс существует.
			if ((_persons.Length != 0) && (_persons.Length >= IndexToDelete))
			{
				var output = new Person[_persons.Length - 1];
				int counter = 0;

				for (int i = 0; i < _persons.Length; i++)
				{
					if (i == IndexToDelete) continue;
					output[counter] = _persons[i];
					counter++;
				}
				_persons = output;
			}

		}

		/// <summary>
		/// Поиск по индексу
		/// </summary>
		/// <param name="indexToSearch"></param>
		/// <returns>Значение соответствующее индексу</returns>
		public Person SearchFromIndex(int indexToSearch)
		{
			if (indexToSearch <= _persons.Length) 
			{
				return _persons[indexToSearch];
			}
			else return null;
		}

		//Метод для поиска индекса по запросу
		/// <summary>
		/// Поиск индекса по запросу
		/// </summary>
		/// <param name="request"></param>
		/// <returns>Массив индексов соответствующих запросу</returns>
		public int[] ReturnTheIndex(string request) 
		{
			int[] indexes = new int[0];
			for (int i = 0; i < _persons.Length; i++)
			{
				if (_persons[i].Name == request || _persons[i].Surname == request)
				{
					Array.Resize<int>(ref indexes, indexes.Length+1);
					indexes[i] = i;
				}
			}
			return indexes;
		}

		//
		/// <summary>
		/// Метод для очистки списка
		/// </summary>
		public void Clear()
		{
			Array.Clear(_persons, 0, _persons.Length);
			Array.Resize<Person>(ref _persons, 0);
		}

		/// <summary>
		/// Количества элементов в списке
		/// </summary>
		/// <returns>Количество элементов в списке</returns>
		public int Count()
		{
			return _persons.Length;
		}



		// индексатор (пока не понятно зачем работает)
		/// <summary>
		/// Индексатор
		/// </summary>
		/// <param name="index"></param>
		/// <returns>Индекс записи</returns>
		public Person this[int index]
		{
			// Для получения объекта по индексу
			get
			{
				return _persons[index];
			}
			//В блоке set получаем через параметр value переданный объект Person и сохраняем его в list по индексу
			set
			{
				_persons[index] = value;
			}
		}
	}
}
