using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Lab1ConsoleApp
{
    
    public enum Gender : byte
    {
        Male,
        Female
    }

    public class Person
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public Gender Gender { get; set; }
        
        //Конструктор класса
        public Person(string n, string s, byte a, Gender g) { Name = n; Surname = s; Age = a;  Gender = g; }

        //Объект генерации
        private static Random RealRnd = new Random(DateTime.Now.Second);

        //Метод для генерация случайной персоны
        static public Person GetRandomPerson()
        {
            //Пул имен и фамилий
            string[] MaleNames = new string[10] { "Ayten", "Sanjay", "Luther", "Allen", "Dominic", "Brett", "Bradford", "Julian", "Kenny", "Sam" };
            string[] FemaleNames = new string[10] { "Maria", "Lydia", "Meghan", "Gloria", "Dixie", "Rita", "Kelley", "Wilma", "Silvia", "Lee" };
            string[] Surnames = new string[10] { "Jones", "Miller", "Daniels", "Gibbs", "Sanders", "Potter", "Rhodes", "Lamb", "Sims", "Jordan" };

            //Переменные в которых хранятся сгенерированные значения
            string Name;
            string Surname;
            byte Age;
            Gender Gender;

            //Генерация пола
            if (RealRnd.Next(1, 3) == 1) { Gender = Gender.Male; }
            else { Gender = Gender.Female; }

            //Имя генерируется в зависимости от пола
            if (Gender == Gender.Male) { Name = MaleNames[RealRnd.Next(0, 9)]; }
            else { Name = FemaleNames[RealRnd.Next(0, 9)]; }

            //Генерация фамилии
            Surname = Surnames[RealRnd.Next(0, 9)];

            //Генерация возраста
            Age = Convert.ToByte(RealRnd.Next(18, 79));


            //на снове получнных данных получаем объект Person
            Person RandomPerson = new Person(Name, Surname, Age, Gender);
            return RandomPerson;
            
        }
        
    }
}
