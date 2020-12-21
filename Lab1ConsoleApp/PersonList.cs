using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
    class PersonList
    {
        //Описание абстракции списка содержащего объекты класса Person
        public Person[] Persons;

        public PersonList()
        {
            Persons = new Person[0];
        }

        //Метод для добавления новых Person
        public Person PersonAdd(Person Person)
        { 
            Array.Resize<Person>(ref Persons, Persons.Length + 1);
            Persons[Persons.Length - 1] = Person;
            return Persons[Persons.Length - 1];
        }

        //Удаление элемента по индексу
        public Person[] PersonDelete(int IndexToDelete)
        {
            // Проверки, что наш массив не пуст и что указанный индекс существует.
            if (Persons.Length == 0) return Persons;
            if (Persons.Length <= IndexToDelete) return Persons;

            var Output = new Person[Persons.Length - 1];
            int Counter = 0;

            for (int i = 0; i < Persons.Length; i++)
            {
                if (i == IndexToDelete) continue;
                Output[Counter] = Persons[i];
                Counter++;
            }
            Persons = Output;
            return Persons;
        }

        //Метод для поиска по индексу
        public Person SearchFromIndex(int IndexToSearch)
        {
            if (IndexToSearch <= Persons.Length) 
            {
                return Persons[IndexToSearch];
            }
            else return null;
        }

        //Метод для поиска индекса по запросу
        public int ReturnTheIndex(string Request) 
        {
            for (int i = 0; i < Persons.Length; i++)
            {
                if (Persons[i].Name == Request || Persons[i].Surname == Request)
                {
                    return i;
                }
            }
            return -1;
        }

        //Метод для очистки списка
        public void Clear()
        {
            Array.Clear(Persons, 0, Persons.Length);
            Array.Resize<Person>(ref Persons, 0);
        }

        //Метод для получения количества элементов в списке
        public int GetTheNumberOfItems()
        {
            return Persons.Length;
        }

        //Метод для вывода списка в консоль
        public void ListToConsole()
        {
            if (Persons.Length == 0) Console.WriteLine("Список пуст!");
            foreach (Person p in Persons)
            {
                Person.PersonToConsole(p);
            }
            Console.WriteLine();
        }



        // индексатор (пока не понятно зачем работает)
        public Person this[int index]
        {
            // Для получения объекта по индексу
            get
            {
                return Persons[index];
            }
            //В блоке set получаем через параметр value переданный объект Person и сохраняем его в list по индексу
            set
            {
                Persons[index] = value;
            }
        }
    }
}
