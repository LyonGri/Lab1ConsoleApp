using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
    class PersonList
    {
        //public List<Person> Persons = new List<Person>();
        public Person[] Persons;
        public PersonList()
        {
            Persons = new Person[0];
            //new List<Person>();
            //Persons.Add(Person.);
        }

        //Метод для добавления новых Person
        //public Person PersonListAdd(string Name, string Surname, byte Age, Gender Gender)
        //{
        //    Array.Resize<Person>(ref Persons, Persons.Length + 1);
        //    int a = Persons.Length;
        //    Persons[Persons.Length - 1] = new Person(Name, Surname, Age, Gender);
        //    return Persons[Persons.Length - 1];
        //}
        public Person PersonListAdd()
        { 
            Array.Resize<Person>(ref Persons, Persons.Length + 1);
            int a = Persons.Length;
            Persons[Persons.Length - 1] = Person.GetRandomPerson();
            return Persons[Persons.Length - 1];
        }



        // индексатор
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
