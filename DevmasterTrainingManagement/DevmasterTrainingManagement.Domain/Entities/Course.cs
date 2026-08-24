namespace DevmasterTrainingManagement.Domain.Entities;

public class Course
{
    public string CourseId { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public decimal TuitionFee { get; set; }
    public int Duration { get; set; } 
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; 
}