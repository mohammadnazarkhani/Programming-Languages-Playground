using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentGradeManager
{
    class Program
    {
        class Lesson
        {
            public int LessonId { get; set; }
            public int Mark { get; set; }
            public Lesson(int id, int mark)
            {
                LessonId = id;
                Mark = mark;
            }

            public override string ToString()
            {
                return LessonId + "," + Mark;
            }
        }

        class Student
        {
            public int StudentId { get; set; }
            public List<Lesson> Lessons { get; private set; }

            public Student(int id)
            {
                StudentId = id;
                Lessons = new List<Lesson>(); // Initialize the list
            }

            public void AddLesson(int id, int mark)
            {
                var lesson = new Lesson(id, mark);
                Lessons.Add(lesson);
            }
        }

        static void CreateStudentsGradesFile(Student std, string gradesDirectoryPath)
        {
            string filePath = gradesDirectoryPath + std.StudentId + ".txt";

            if (!Directory.Exists(gradesDirectoryPath))
            {
                Directory.CreateDirectory(gradesDirectoryPath);
            }

            File.WriteAllLines(filePath, std.Lessons.Select(lsn => lsn.ToString()));
        }


        static void Main(string[] args)
        {
            string stdFilePath = "Students.txt";
            string gradesDirectoryPath = "grades/";

            var stds = PopulateAllStudents(stdFilePath);

            CreateAllStudentsGradesFiles(stds, gradesDirectoryPath);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        static string[] GetAllCsvLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        static int[] ConvertRecordToInt(string record)
        {
            string[] fields = record.Split(',');
            int[] convertedRecord = new int[fields.Length];
            for (int i = 0; i < fields.Length; i++)
                convertedRecord[i] = int.Parse(fields[i]);

            return convertedRecord;
        }

        static List<int[]> GetAllRecordsData(string[] allLines)
        {
            var allRecords = new List<int[]>();

            foreach (var record in allLines)
            {
                allRecords.Add(ConvertRecordToInt(record));
            }

            return allRecords;
        }

        static int GetIndexIfStudentExistsWithId(List<Student> stds, int id)
        {
            for (int i = 0; i < stds.Count; i++)
                if (stds[i].StudentId == id)
                    return i;

            return -1;
        }

        static List<Student> GetAllStudents(List<int[]> allRecords)
        {
            List<Student> stds = new List<Student>();

            foreach (var record in allRecords)
            {
                int existenceIndex = GetIndexIfStudentExistsWithId(stds, record[0]);
                if (existenceIndex == -1)
                {
                    var newStd = new Student(record[0]);
                    newStd.AddLesson(record[1], record[2]);
                    stds.Add(newStd);
                }
                else
                {
                    stds[existenceIndex].AddLesson(record[1], record[2]);
                }
            }

            return stds;
        }

        static List<Student> PopulateAllStudents(string stdFilePath)
        {
            string[] allLines = GetAllCsvLines(stdFilePath);
            var allRecords = GetAllRecordsData(allLines);

            List<Student> allStds = GetAllStudents(allRecords);

            return allStds;
        }

        static void CreateAllStudentsGradesFiles(List<Student> stds, string gradesDirectoryPath)
        {
            foreach (var std in stds)
            {
                CreateStudentsGradesFile(std, gradesDirectoryPath);
            }
        }
    }
}
