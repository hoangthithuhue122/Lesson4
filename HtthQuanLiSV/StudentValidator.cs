using System.Text.RegularExpressions;

namespace HtthQuanLiSV
{
    public static class StudentValidator
    {
        public static bool isValidHoTen(string hoTen) => !string.IsNullOrWhiteSpace(hoTen);
        
        public static bool isValidDiem(float diemTrungBinh) => diemTrungBinh >= 0 && diemTrungBinh <= 10;
        
        public static bool isValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}