namespace DevmasterTrainingManagement.Domain.Entities;

public class Enrollment
{
    public string EnrollmentId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string ClassId { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public decimal TuitionFee { get; set; } // Học phí cần đóng
    public decimal PaidAmount { get; set; } // Số tiền đã đóng
    public string PaymentStatus { get; set; } = string.Empty; // Trạng thái thanh toán
}