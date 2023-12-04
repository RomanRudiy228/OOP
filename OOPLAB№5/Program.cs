using System;
using System.Collections.Generic;

public class Test
{
    public string Subject { get; set; }
    public int Score { get; set; }
}

public class Exam
{
    public string Subject { get; set; }
    public int Score { get; set; }
}

public class Person : IComparable<Person>, IComparer<Person>
{
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public int CompareTo(Person other)
    {
        return string.Compare(LastName, other.LastName, StringComparison.Ordinal);
    }   

    public int Compare(Person x, Person y)
    {
        return DateTime.Compare(x.BirthDate, y.BirthDate);
    }
}

public class Student : Person
{
    public List<Test> Tests { get; set; } = new List<Test>();
    public List<Exam> Exams { get; set; } = new List<Exam>();

    public double CalculateAverageMark()
    {
        double totalScore = 0;
        int totalTestsAndExams = Tests.Count + Exams.Count;

        foreach (var test in Tests)
        {
            totalScore += test.Score;
        }

        foreach (var exam in Exams)
        {
            totalScore += exam.Score;
        }

        return totalTestsAndExams > 0 ? totalScore / totalTestsAndExams : 0;
    }
}

public class AverageMarkComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        double averageX = x.CalculateAverageMark();
        double averageY = y.CalculateAverageMark();

        return averageX.CompareTo(averageY);
    }
}

public class StudentCollection
{
    private List<Student> students = new List<Student>();

    public void AddDefaults()
    {
        students.Add(new Student
        {
            LastName = "Thomas",
            BirthDate = new DateTime(2000, 01, 11),
            Tests = new List<Test> { new Test { Subject = "Math", Score = 90 } },
            Exams = new List<Exam> { new Exam { Subject = "History", Score = 85 } }

        });

        students.Add(new Student
        {
            LastName = "Mark",
            BirthDate = new DateTime(2004, 02, 12),
            Tests = new List<Test> { new Test { Subject = "OOP", Score = 75 } },
            Exams = new List<Exam> { new Exam { Subject = "Languege", Score = 60 } }

        });

        students.Add(new Student
        {
            LastName = "John",
            BirthDate = new DateTime(1999, 12, 30),
            Tests = new List<Test> { new Test { Subject = "PE", Score = 90 } },
            Exams = new List<Exam> { new Exam { Subject = "Algorithm", Score = 70 } }

        });

        students.Add(new Student
        {
            LastName = "Yarik",
            BirthDate = new DateTime(2005, 12, 18),
            Tests = new List<Test> { new Test { Subject = "Physic", Score = 85 } },
            Exams = new List<Exam> { new Exam { Subject = "English", Score = 89 } }

        });

        students.Add(new Student
        {
            LastName = "Joshe",
            BirthDate = new DateTime(2004, 02, 12),
            Tests = new List<Test> { new Test { Subject = "OP", Score = 79 } },
            Exams = new List<Exam> { new Exam { Subject = "OIPZ", Score = 75 } }

        });

        students.Add(new Student
        {
            LastName = "Vika",
            BirthDate = new DateTime(2005, 03, 02),
            Tests = new List<Test> { new Test { Subject = "Chemestry", Score = 90 } },
            Exams = new List<Exam> { new Exam { Subject = "Math", Score = 75 } }

        });
    }

    public void AddStudents(params Student[] newStudents)
    {
        students.AddRange(newStudents);
    }

    public void SortByLastName()
    {
        students.Sort();
    }

    public void SortByBirthDate()
    {
        students.Sort(new Person());
    }

    public void SortByAverageMark()
    {
        students.Sort(new AverageMarkComparer());
    }

    public override string ToString()
    {
        string result = "";
        foreach (var student in students)
        {
            result += $"{student.LastName}, {student.BirthDate.ToShortDateString()}, Average Mark: {student.CalculateAverageMark()}\n";
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        StudentCollection studentCollection = new StudentCollection();
        studentCollection.AddDefaults();

        Console.WriteLine("Before Sorting:");
        Console.WriteLine(studentCollection.ToString());

        studentCollection.SortByLastName();
        Console.WriteLine("\nAfter Sorting by Last Name:");
        Console.WriteLine(studentCollection.ToString());

        studentCollection.SortByBirthDate();
        Console.WriteLine("\nAfter Sorting by Birth Date:");
        Console.WriteLine(studentCollection.ToString());

        studentCollection.SortByAverageMark();
        Console.WriteLine("\nAfter Sorting by Average Mark:");
        Console.WriteLine(studentCollection.ToString());

    }
}
