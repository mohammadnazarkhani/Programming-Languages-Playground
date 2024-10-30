using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintDistinguishedStudent.Models;

namespace PrintDistinguishedStudent.Repositories
{
    public class StudentsRepository
    {
        List<Student> stds = new List<Student>();

        public void InputStudents(int numberOfStdsToInput)
        {
            for (int i = 0; i < numberOfStdsToInput; i++)
            {
                Console.WriteLine($"Enter {i + 1}th student's information:");
                Console.Write($"FirstName: ");
                string fName = Console.ReadLine();
                Console.Write($"LastName: ");
                string lName = Console.ReadLine();
                Console.Write($"GPA: ");
                double gpa;
                while (!double.TryParse(Console.ReadLine(), out gpa))
                {
                    Console.WriteLine("Pleas enter correct number as GPA: ");
                }
                Console.WriteLine();

                Student std = new Student(fName, lName, gpa);
                this.stds.Add(std);
            }
        }

        public List<Student> QueryStudents() => stds;
    }
}
