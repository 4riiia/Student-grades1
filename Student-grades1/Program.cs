using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Call the method directly to avoid ENC0118 issues during debugging
        RunStudentGradesProgram();
    }

    static void RunStudentGradesProgram()
    {
        List<Student> students = new List<Student>();
        string input;

        Console.WriteLine("Welcome to the Student Grades Program!");
        Console.WriteLine("Enter student names and grades. Type 'done' when finished.");

        while (true)
        {
            Console.Write("Enter student name (or 'done' to finish): ");
            input = Console.ReadLine() ?? string.Empty;

            if (input?.ToLower() == "done")
                break;

            Console.Write("Enter student grade: ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                students.Add(new Student { Name = input ?? string.Empty, Grade = grade });
            }
            else
            {
                Console.WriteLine("Invalid grade. Please enter a valid number.");
            }
        }

        while (true)
        {
            Console.WriteLine("\nWould you like to update a student's grade? (yes/no): ");
            string? updateChoice = Console.ReadLine()?.ToLower();

            if (updateChoice == "no")
                break;

            Console.Write("Enter the name of the student to update: ");
            string studentName = Console.ReadLine();

            if (string.IsNullOrEmpty(studentName))
            {
                Console.WriteLine("Invalid input. Please enter a valid student name.");
                continue;
            }
            if (string.IsNullOrEmpty(studentName))
            {
                Console.WriteLine("Invalid input. Please enter a valid student name.");
                continue;
            }
            var student = students.Find(s => s.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                Console.Write("Enter the new grade: ");
                if (int.TryParse(Console.ReadLine(), out int newGrade))
                {
                    student.Grade = newGrade;
                    Console.WriteLine("Grade updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid grade. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        Console.WriteLine("\nStudent Results:");
        foreach (var student in students)
        {
            string status = student.Grade >= 60 ? "Passed" : "Failed";
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Status: {status}");
        }
    }
}

class Student
{
    public string Name { get; set; } = string.Empty; // Initialize with a default value
    public int Grade { get; set; }
}
