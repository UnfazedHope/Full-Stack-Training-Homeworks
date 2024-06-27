namespace Assignment3;

public interface IStudentService : IPersonService
{
    void EnrollInCourse(Student student, Course course);
    void DisplayStudentGPA(Student student);
}