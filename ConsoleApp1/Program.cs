using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("1. Visa alla studenter");
            Console.WriteLine("2. Visa studenter i en klass");
            Console.WriteLine("3. Lägg till student");
            Console.WriteLine("4. Visa personal");
            Console.WriteLine("5. Lägg till personal");
            Console.WriteLine("6. Avsluta");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllStudents(db);
                    break;

                case "2":
                    ShowStudentsInClass(db);
                    break;

                case "3":
                    AddStudent(db);
                    break;

                case "4":
                    ShowStaff(db);
                    break;

                case "5":
                    AddStaff(db);
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Felaktigt val.");
                    break;
            }
        }
    }

    static void ShowAllStudents(AppDbContext db)
    {
        Console.WriteLine("Sortera efter (1=Förnamn, 2=Efternamn):");
        var sortOption = Console.ReadLine();

        Console.WriteLine("Sortering (1=Stigande, 2=Fallande):");
        var sortOrder = Console.ReadLine();

        var students = db.Students.Include(s => s.Class).AsQueryable();

        if (sortOption == "1")
            students = sortOrder == "1"
                ? students.OrderBy(s => s.FirstName)
                : students.OrderByDescending(s => s.FirstName);
        else
            students = sortOrder == "1"
                ? students.OrderBy(s => s.LastName)
                : students.OrderByDescending(s => s.LastName);

        foreach (var s in students)
            Console.WriteLine($"{s.FirstName} {s.LastName} - Klass: {s.Class?.ClassName}");
    }

    static void ShowStudentsInClass(AppDbContext db)
    {
        var classes = db.Classes.ToList();

        for (int i = 0; i < classes.Count; i++)
            Console.WriteLine($"{i + 1}. {classes[i].ClassName}");

        Console.WriteLine("Välj klass:");
        int choice = int.Parse(Console.ReadLine()!) - 1;

        var selectedClass = classes[choice];

        var students = db.Students
            .Where(s => s.ClassId == selectedClass.ClassId)
            .OrderBy(s => s.LastName)
            .ToList();

        Console.WriteLine($"\nStudenter i {selectedClass.ClassName}:");
        foreach (var s in students)
            Console.WriteLine($"{s.FirstName} {s.LastName}");
    }

    static void AddStudent(AppDbContext db)
    {
        Console.WriteLine("Förnamn:");
        var firstName = Console.ReadLine();

        Console.WriteLine("Efternamn:");
        var lastName = Console.ReadLine();

        Console.WriteLine("Personnummer:");
        var personNumber = Console.ReadLine();

        var classes = db.Classes.ToList();
        for (int i = 0; i < classes.Count; i++)
            Console.WriteLine($"{i + 1}. {classes[i].ClassName}");

        Console.WriteLine("Välj klass:");
        int choice = int.Parse(Console.ReadLine()!) - 1;

        db.Students.Add(new Student
        {
            FirstName = firstName!,
            LastName = lastName!,
            PersonNumber = personNumber!,
            ClassId = classes[choice].ClassId
        });

        db.SaveChanges();
        Console.WriteLine("Student tillagd!");
    }

    static void ShowStaff(AppDbContext db)
    {
        foreach (var s in db.Staff)
            Console.WriteLine($"{s.StaffFirstName} {s.StaffLastName} - {s.StaffWork}");
    }

    static void AddStaff(AppDbContext db)
    {
        Console.WriteLine("Förnamn:");
        var firstName = Console.ReadLine();

        Console.WriteLine("Efternamn:");
        var lastName = Console.ReadLine();

        Console.WriteLine("Arbetskategori:");
        var work = Console.ReadLine();

        db.Staff.Add(new Staff
        {
            StaffFirstName = firstName!,
            StaffLastName = lastName!,
            StaffWork = work!
        });

        db.SaveChanges();
        Console.WriteLine("Personal tillagd!");
    }
}