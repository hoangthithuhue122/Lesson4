using System;
using System.Collections.Generic;
using System.Linq;

namespace HtthQuanLiSV
{
    public class StudentService
    {
        private List<Student> _students = new List<Student>();

        public bool AddStudent(Student student)
        {
            if (_students.Any(s => s.maSV == student.maSV)) return false; 
            _students.Add(student);
            return true;
        }

        public List<Student> GetAll() => _students;

        public Student? GetByMaSV(string ma) => _students.FirstOrDefault(s => s.maSV == ma);

        public List<Student> SearchByName(string name) => 
            _students.Where(s => s.hoTen.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        public bool UpdateStudent(string ma, Student updatedData)
        {
            var student = GetByMaSV(ma);
            if (student == null) return false;

            student.hoTen = updatedData.hoTen;
            student.ngaySinh = updatedData.ngaySinh;
            student.gioiTinh = updatedData.gioiTinh;
            student.email = updatedData.email;
            student.sDT = updatedData.sDT;
            student.nganhHoc = updatedData.nganhHoc;
            student.diemTrungBinh = updatedData.diemTrungBinh;
            student.trangThai = updatedData.trangThai;
            return true;
        }

        public bool DeleteStudent(string ma)
        {
            var student = GetByMaSV(ma);
            if (student == null) return false;
            _students.Remove(student);
            return true;
        }

        public List<Student> SortByName() => _students.OrderBy(s => s.hoTen).ToList();

        public List<Student> SortByDiemTB() => _students.OrderByDescending(s => s.diemTrungBinh).ToList();

        public List<Student> GetStudentsScore8Plus() => _students.Where(s => s.diemTrungBinh >= 8).ToList();

        public List<Student> GetTopScoreStudents()
        {
            if (!_students.Any()) return new List<Student>();
            float maxScore = _students.Max(s => s.diemTrungBinh);
            return _students.Where(s => s.diemTrungBinh == maxScore).ToList();
        }

        public float GetAverageScoreAll() => _students.Any() ? _students.Average(s => s.diemTrungBinh) : 0;

        public Dictionary<string, int> GetStatsByMajor() => 
            _students.GroupBy(s => s.nganhHoc).ToDictionary(g => g.Key, g => g.Count());

        public Dictionary<string, int> GetStatsByStatus() => 
            _students.GroupBy(s => s.trangThai).ToDictionary(g => g.Key, g => g.Count());
    }
}