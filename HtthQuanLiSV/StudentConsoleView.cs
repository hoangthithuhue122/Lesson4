using System;
using System.Collections.Generic;
using System.Linq;

namespace HtthQuanLiSV
{
    public class StudentConsoleView
    {
        public Student InputNewStudent(StudentService service)
        {
            Student sv = new Student();
            
            while (true)
            {
                Console.Write("Nhập mã SV: ");
                sv.maSV = Console.ReadLine() ?? "";
                if (service.GetByMaSV(sv.maSV) != null) Console.WriteLine("Mã SV đã tồn tại. Vui lòng nhập lại!");
                else break;
            }

            while (true)
            {
                Console.Write("Nhập họ tên: ");
                sv.hoTen = Console.ReadLine() ?? "";
                if (!StudentValidator.isValidHoTen(sv.hoTen)) Console.WriteLine("Họ tên không được rỗng!");
                else break;
            }

            Console.Write("Nhập ngày sinh (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime ns);
            sv.ngaySinh = ns;

            Console.Write("Giới tính (Nhập 'Nam' hoặc 'Nu' - mặc định là Nữ): ");
            string gt = Console.ReadLine()?.Trim().ToLower() ?? "";
            sv.gioiTinh = (gt == "nam"); 

            while (true)
            {
                Console.Write("Nhập Email: ");
                sv.email = Console.ReadLine() ?? "";
                if (!StudentValidator.isValidEmail(sv.email)) Console.WriteLine("Email không đúng định dạng!");
                else break;
            }

            Console.Write("Nhập số điện thoại: ");
            sv.sDT = Console.ReadLine() ?? "";

            Console.Write("Nhập ngành học: ");
            sv.nganhHoc = Console.ReadLine() ?? "";

            while (true)
            {
                Console.Write("Nhập điểm TB (0-10): ");
                if (float.TryParse(Console.ReadLine(), out float diem) && StudentValidator.isValidDiem(diem))
                {
                    sv.diemTrungBinh = diem;
                    break;
                }
                Console.WriteLine("Điểm TB không hợp lệ!");
            }

            Console.Write("Nhập trạng thái học tập: ");
            sv.trangThai = Console.ReadLine() ?? "";

            return sv;
        }

        public void DisplayStudent(Student s)
        {
            string gioiTinhStr = s.gioiTinh ? "Nam" : "Nữ";
            Console.WriteLine($"Mã: {s.maSV,-10} | Tên: {s.hoTen,-20} | Giới tính: {gioiTinhStr,-5} | Ngành: {s.nganhHoc,-15} | Điểm: {s.diemTrungBinh,-5} | Trạng thái: {s.trangThai}");
        }

        public void DisplayList(List<Student> list)
        {
            if (!list.Any()) Console.WriteLine("Danh sách trống!");
            else list.ForEach(DisplayStudent);
        }
    }
}