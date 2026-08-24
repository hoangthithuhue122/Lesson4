namespace DevmasterTrainingManagement.Domain.Entities;

public class ClassRoom
{
    public string ClassId { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string CourseId { get; set; } = string.Empty; // Liên kết với Khóa học
    public DateTime OpeningDate { get; set; }
    public string Schedule { get; set; } = string.Empty; // Lịch học
    public int MaxCapacity { get; set; }
    public string Status { get; set; } = string.Empty; // Trạng thái: Sắp khai giảng, Đang học...
}