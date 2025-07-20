using P01_StudentSystem.Data;
using P01_StudentSystem.Models;

namespace P01_StudentSystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            string? input;

            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("V => View all students");
                Console.WriteLine("A => Add new student");
                Console.WriteLine("Q => Quit");

                input = Console.ReadLine()?.ToLower().Trim();

                switch (input)
                {
                    case "v":
                        var students = context.Students.ToList();

                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                        }
                        else
                        {
                            Console.WriteLine("All Students:\n");
                            foreach (var student in students)
                            {
                                Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}, Phone: {student.PhoneNumber}, Birthday: {student.Birthday}, Registered: {student.RegisteredOn}");
                            }
                        }
                        break;

                    case "a":
                        Console.WriteLine("Enter student name:");
                        string? name = Console.ReadLine();

                        Console.WriteLine("Enter phone number:");
                        string? phone = Console.ReadLine();

                        Console.WriteLine("Enter birthday (e.g. 15/05/2000 or 2000-05-15):");
                        string? birthdayInput = Console.ReadLine();
                        DateOnly? birthday = null;

                        if (!string.IsNullOrWhiteSpace(birthdayInput))
                        {
                            if (DateOnly.TryParse(birthdayInput, out var parsedDate))
                            {
                                birthday = parsedDate;
                            }
                            else
                            {
                                Console.WriteLine("Invalid birthday format. Skipping birthday.");
                            }
                        }

                        var studentToAdd = new Student
                        {
                            Name = name ?? string.Empty,
                            PhoneNumber = phone,
                            Birthday = birthday,
                            RegisteredOn = DateTime.Now
                        };

                        context.Students.Add(studentToAdd);
                        context.SaveChanges();

                        Console.WriteLine("Student added successfully.");
                        break;

                    case "q":
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Unknown option. Please try again.");
                        break;
                }

                Console.WriteLine(); 

            } while (input != "q");



        }
    }
}
