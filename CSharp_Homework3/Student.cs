namespace Assignment3;

public class Student : Person
{
    private Dictionary<Course, char> courses = new Dictionary<Course, char>();

    public void AddCourse(Course course, char grade)
    {
        courses[course] = grade;
    }

    public Dictionary<Course, char> GetCourses()
    {
        return courses;
    }

    public double CalculateGPA()
    {
        double totalPoints = 0;
        int totalCourses = courses.Count;

        foreach (var grade in courses.Values)
        {
            totalPoints += GradeToPoint(grade);
        }

        return totalCourses == 0 ? 0 : totalPoints / totalCourses;
    }

    private double GradeToPoint(char grade)
    {
        switch (grade)
        {
            case 'A': return 4.0;
            case 'B': return 3.0;
            case 'C': return 2.0;
            case 'D': return 1.0;
            case 'F': return 0.0;
            default: return 0.0;
        }
    }
}