namespace ConsoleApp1.Models;

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = "";

    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public List<Grade> Grades { get; set; } = new();
}
