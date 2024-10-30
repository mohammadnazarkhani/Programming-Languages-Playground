using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDistinguishedStudent.Models
{
    public struct Student
    {
        string _firstName;
        string _lastName;
        double _gpa;

        public Student(string firstName, string lastName, double gpa)
        {
            _firstName = firstName;
            _lastName = lastName;
            _gpa = gpa;
        }

        public void Display()
        {
            Console.WriteLine($"{_firstName} {_lastName} with GPA of {_gpa}.");
        }

        public double GetGpa() => _gpa;
    }
}
