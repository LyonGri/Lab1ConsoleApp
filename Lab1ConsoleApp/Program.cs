using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Первый список персон
            PersonList PersonListOne = new PersonList();
            //PersonListOne[0] = new Person("Elon", "Musk", 49, Gender.Male);
            //PersonListOne.Persons[1] = new Person("Tim", "Cook", 60, Gender.Male);
            //PersonListOne.PersonListAdd("Billie", "Eilish", 19, Gender.Female);

            
            //заполняем списки
            for (int i = 0; i < 3; i++)
            {
                PersonListOne.PersonListAdd();
            }


            foreach (Person p in PersonListOne.Persons)
            {
                Console.WriteLine(p.Name + " " + p.Surname + " " + p.Age + " " + p.Gender);
            }
            Console.ReadKey();
        }
    }
}
