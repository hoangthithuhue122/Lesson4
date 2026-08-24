using DevmasterTrainingManagement.Domain.Entities;

namespace DevmasterTrainingManagement.Application.Interfaces;

public interface ICourseService
{
    void Add(Course course);
    void Update(Course course);
    void Delete(string courseId);
    List<Course> GetAll();
    List<Course> Search(string keyword);
    List<Course> SortByTuition();
    List<Course> FilterByStatus(string status);
    decimal GetTotalTuition();
}