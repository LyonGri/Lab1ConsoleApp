using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1ConsoleApp
{

    public class Person
    {
        string Name;
        string Surname;
        byte Age;
        public enum Gender : byte
        {
            Male,
            Female
        }
        public Person(string n, string s, byte a, Gender g) { Name = n; Surname = s; Age = a; g; }
    }
}
