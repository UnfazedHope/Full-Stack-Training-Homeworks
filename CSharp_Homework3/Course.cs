namespace Assignment3;

public class Course
{
    public string CourseName { get; set; }
    public List<Student> EnrolledStudents { get; } = new List<Student>();
}