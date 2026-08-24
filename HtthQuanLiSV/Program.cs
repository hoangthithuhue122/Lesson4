
using System;

namespace HtthQuanLiSV
{
    public class MenuManager
    {
        private StudentService _service = new StudentService();
        private StudentConsoleView _view = new StudentConsoleView();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== QUẢN LÝ SINH VIÊN OOP ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách");
                Console.WriteLine("3. Tìm sinh viên theo mã");
                Console.WriteLine("4. Tìm gần đúng theo họ tên");
                Console.WriteLine("5. Cập nhật sinh viên");
                Console.WriteLine("6. Xóa sinh viên");
                Console.WriteLine("7. Sắp xếp theo họ tên");
                Console.WriteLine("8. Sắp xếp theo điểm trung bình");
                Console.WriteLine("9. Hiển thị sinh viên có điểm từ 8 trở lên");
                Console.WriteLine("10. Hiển thị sinh viên có điểm cao nhất");
                Console.WriteLine("11. Tính điểm trung bình toàn bộ sinh viên");
                Console.WriteLine("12. Thống kê sinh viên theo ngành");
                Console.WriteLine("13. Thống kê sinh viên theo trạng thái");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                
                string choice = Console.ReadLine() ?? "";
                
                switch (choice)
                {
                    case "1":
                        _service.AddStudent(_view.InputNewStudent(_service));
                        Console.WriteLine("Đã thêm");
                        break;
                    case "2":
                        _view.DisplayList(_service.GetAll());
                        break;
                    case "3":
                        Console.Write("Nhập MSV: ");
                        var sv = _service.GetByMaSV(Console.ReadLine() ?? "");
                        if (sv != null) _view.DisplayStudent(sv);
                        else Console.WriteLine("Không tìm thấy!");
                        break;
                    case "4":
                        Console.Write("Nhập tên cần tìm: ");
                        _view.DisplayList(_service.SearchByName(Console.ReadLine() ?? ""));
                        break;
                    case "5":
                        Console.Write("Nhập MSV cần cập nhật: ");
                        string maCapNhat = Console.ReadLine() ?? "";
                        if (_service.GetByMaSV(maCapNhat) != null)
                        {
                            Console.WriteLine("Nhập thông tin mới:");
                            var newData = _view.InputNewStudent(_service); 
                            newData.maSV = maCapNhat; 
                            _service.UpdateStudent(maCapNhat, newData);
                            Console.WriteLine("Cập nhật thành công");
                        }
                        else Console.WriteLine("Sinh viên không tồn tại");
                        break;
                    case "6":
                        Console.Write("Nhập MSV cần xóa: ");
                        if (_service.DeleteStudent(Console.ReadLine() ?? "")) Console.WriteLine("Xóa thành công!");
                        else Console.WriteLine("Sinh viên không tồn tại!");
                        break;
                    case "7":
                        _view.DisplayList(_service.SortByName());
                        break;
                    case "8":
                        _view.DisplayList(_service.SortByDiemTB());
                        break;
                    case "9":
                        _view.DisplayList(_service.GetStudentsScore8Plus());
                        break;
                    case "10":
                        _view.DisplayList(_service.GetTopScoreStudents());
                        break;
                    case "11":
                        Console.WriteLine("Điểm trung bình toàn bộ: {_service.GetAverageScoreAll():F2}");
                        break;
                    case "12":
                        foreach (var kvp in _service.GetStatsByMajor())
                            Console.WriteLine("Ngành {kvp.Key}: {kvp.Value} sinh viên");
                        break;
                    case "13":
                        foreach (var kvp in _service.GetStatsByStatus())
                            Console.WriteLine("Trạng thái {kvp.Key}: {kvp.Value} sinh viên");
                        break;
                    case "0":
                        Console.WriteLine("Chương trình kết thúc.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            
            MenuManager menu = new MenuManager();
            menu.Run();
        }
    }
}