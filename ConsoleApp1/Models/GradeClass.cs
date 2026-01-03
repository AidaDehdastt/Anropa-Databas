namespace ConsoleApp1.Models;

public class Grade
{
    public int GradeId { get; set; }
    public string? GradeValue { get; set; }
    public DateTime? GradeDate { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}
