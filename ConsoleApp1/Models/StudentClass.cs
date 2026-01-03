namespace ConsoleApp1.Models;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PersonNumber { get; set; } = "";

    public int ClassId { get; set; }
    public Class? Class { get; set; }

    public List<Course> Courses { get; set; } = new();
}
