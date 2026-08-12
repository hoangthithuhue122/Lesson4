using System;

namespace HtthQuanLiSV
{
    public class Student
    {
        public string maSV { get; set; } = string.Empty;
        public string hoTen { get; set; } = string.Empty;
        public DateTime ngaySinh { get; set; }
        public bool gioiTinh { get; set; }
        public string email { get; set; } = string.Empty;
        public string sDT { get; set; } = string.Empty;
        public string nganhHoc { get; set; } = string.Empty;
        public float diemTrungBinh { get; set; }
        public string trangThai { get; set; } = string.Empty;
    }
}