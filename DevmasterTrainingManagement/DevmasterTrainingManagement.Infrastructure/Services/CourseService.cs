using DevmasterTrainingManagement.Application.Interfaces;
using DevmasterTrainingManagement.Domain.Entities;
using DevmasterTrainingManagement.Infrastructure.Data;

namespace DevmasterTrainingManagement.Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly string _filePath = "courses.json";
    private List<Course> _courses;

    public CourseService()
    {
        // Tự động load dữ liệu khi khởi chạy Service
        _courses = JsonStorage.Load<List<Course>>(_filePath);
    }

    private void Save() => JsonStorage.Save(_filePath, _courses);

    public void Add(Course course)
    {
        _courses.Add(course);
        Save();
    }

    public void Update(Course course)
    {
        var existing = _courses.FirstOrDefault(c => c.CourseId == course.CourseId);
        if (existing != null)
        {
            existing.CourseName = course.CourseName;
            existing.TuitionFee = course.TuitionFee;
            existing.Duration = course.Duration;
            existing.Description = course.Description;
            existing.Status = course.Status;
            Save();
        }
    }

    public void Delete(string courseId)
    {
        _courses.RemoveAll(c => c.CourseId == courseId);
        Save();
    }

    public List<Course> GetAll() => _courses;

    // Tìm kiếm tương đối theo ID hoặc Tên
    public List<Course> Search(string keyword) => 
        _courses.Where(c => c.CourseName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                            c.CourseId.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

    // Sắp xếp học phí tăng dần
    public List<Course> SortByTuition() => 
        _courses.OrderBy(c => c.TuitionFee).ToList();

    public List<Course> FilterByStatus(string status) => 
        _courses.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();

    public decimal GetTotalTuition() => 
        _courses.Sum(c => c.TuitionFee);
}