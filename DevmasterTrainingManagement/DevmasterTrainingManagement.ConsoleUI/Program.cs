using System;
using DevmasterTrainingManagement.Domain.Entities;
using DevmasterTrainingManagement.Infrastructure.Services;

namespace DevmasterTrainingManagement.ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        // Hiển thị tiếng Việt có dấu trong Console
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        var courseService = new CourseService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== HỆ THỐNG QUẢN LÝ ĐÀO TẠO DEVMASTER ===");
            Console.WriteLine("1. Thêm khóa học");
            Console.WriteLine("2. Hiển thị danh sách khóa học");
            Console.WriteLine("3. Tìm kiếm khóa học");
            Console.WriteLine("4. Sắp xếp khóa học theo học phí");
            Console.WriteLine("5. Thống kê tổng học phí");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng (0-5): ");
            
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    var course = new Course();
                    Console.Write("Nhập mã khóa học: "); course.CourseId = Console.ReadLine() ?? "";
                    Console.Write("Nhập tên khóa học: "); course.CourseName = Console.ReadLine() ?? "";
                    Console.Write("Nhập học phí: "); course.TuitionFee = decimal.TryParse(Console.ReadLine(), out decimal fee) ? fee : 0;
                    Console.Write("Thời lượng (giờ): "); course.Duration = int.TryParse(Console.ReadLine(), out int time) ? time : 0;
                    Console.Write("Mô tả: "); course.Description = Console.ReadLine() ?? "";
                    Console.Write("Trạng thái (Mở/Đóng): "); course.Status = Console.ReadLine() ?? "";
                    
                    courseService.Add(course);
                    Console.WriteLine("=> Đã thêm khóa học và lưu vào file JSON!");
                    break;

                case "2":
                    Console.WriteLine("\n--- DANH SÁCH KHÓA HỌC ---");
                    foreach (var c in courseService.GetAll())
                    {
                        Console.WriteLine($"Mã: {c.CourseId} | Tên: {c.CourseName} | Học phí: {c.TuitionFee:N0}đ | Trạng thái: {c.Status}");
                    }
                    break;

                case "3":
                    Console.Write("\nNhập mã hoặc tên cần tìm: ");
                    string keyword = Console.ReadLine() ?? "";
                    var results = courseService.Search(keyword);
                    foreach (var c in results)
                    {
                        Console.WriteLine($"Mã: {c.CourseId} | Tên: {c.CourseName}");
                    }
                    break;

                case "4":
                    Console.WriteLine("\n--- KHÓA HỌC SẮP XẾP THEO HỌC PHÍ TĂNG DẦN ---");
                    foreach (var c in courseService.SortByTuition())
                    {
                        Console.WriteLine($"Học phí: {c.TuitionFee:N0}đ | Tên: {c.CourseName}");
                    }
                    break;

                case "5":
                    Console.WriteLine($"\n=> Tổng học phí tất cả các khóa: {courseService.GetTotalTuition():N0}đ");
                    break;

                case "0":
                    Console.WriteLine("Tạm biệt!");
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }

            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    }
}