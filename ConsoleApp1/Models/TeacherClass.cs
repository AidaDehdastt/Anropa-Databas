namespace ConsoleApp1.Models;

public class Teacher
{
    public int TeacherId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

    public List<Class> Classes { get; set; } = new();
    public List<Grade> Grades { get; set; } = new();
}