namespace Assignment3;

public interface IInstructorService : IPersonService
{
    void AssignToDepartment(Instructor instructor, Department department);
    void DisplayInstructorInfo(Instructor instructor);
}