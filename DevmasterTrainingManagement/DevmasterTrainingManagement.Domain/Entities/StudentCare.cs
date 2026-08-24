namespace DevmasterTrainingManagement.Domain.Entities;

public class StudentCare
{
    public string CareId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public DateTime CareDate { get; set; }
    public string ContactChannel { get; set; } = string.Empty; // Kênh liên hệ
    public string Content { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public DateTime? NextAppointmentDate { get; set; } // Có thể null nếu không có lịch hẹn
}