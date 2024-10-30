using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintDistinguishedStudent.Repositories;

namespace PrintDistinguishedStudent

{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsRepository stdRepo = new StudentsRepository();

            stdRepo.InputStudents(2);

            var maxGpaStd = stdRepo.QueryStudents().OrderByDescending(std => std.GetGpa()).FirstOrDefault();
            Console.WriteLine("\nSee the profile of the distinguished student below:");
            maxGpaStd.Display();

            Console.WriteLine("\nPress Any Key to Exit the app ...");
            Console.ReadKey();
        }
    }
}
