namespace Assignment3;

public class StudentService : PersonService, IStudentService
{
    public void EnrollInCourse(Student student, Course course)
    {
        course.EnrolledStudents.Add(student);
    }

    public void DisplayStudentGPA(Student student)
    {
        Console.WriteLine($"{student.Name}'s GPA: {student.CalculateGPA()}");
    }
}