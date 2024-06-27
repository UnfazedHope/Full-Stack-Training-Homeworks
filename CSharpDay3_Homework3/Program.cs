// See https://aka.ms/new-console-template for more information

using Assignment3;


// Problem 1
Problem1 pb1 = new Problem1();
int[] numbers = pb1.GenerateNumbers(10);
Console.WriteLine("Original Array:");
pb1.PrintNumbers(numbers);
        
pb1.Reverse(numbers);
Console.WriteLine("Reversed Array:");
pb1.PrintNumbers(numbers);
Console.WriteLine();


// Problem 2
Problem2 pb2 = new Problem2();
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"Fibonacci({i}) = {pb2.Fibonacci(i)}");
}
Console.WriteLine();



// Problems with OOPS

// Solution to 1-6 problem is with same classes and interfaces

Student student = new Student { Name = "Vishal", BirthDate = new DateTime(2000, 01, 24) };
student.AddAddress("470S 1600E St");
student.AddAddress("355 Main St");

Instructor instructor = new Instructor { Name = "Antra", BirthDate = new DateTime(1975, 6, 15), JoinDate = new DateTime(2000, 9, 1), Salary = 50000 };

Department department = new Department { DepartmentName = "Computer Science", Budget = 1000000, BudgetStart = new DateTime(2024, 1, 1), BudgetEnd = new DateTime(2024, 12, 31) };

Course course = new Course { CourseName = "Introduction to C#" };

// Services acc to problem
IStudentService studentService = new StudentService();
IInstructorService instructorService = new InstructorService();

// Enrolling student in a course
studentService.EnrollInCourse(student, course);
student.AddCourse(course, 'A');

// Assigning instructor to department
instructorService.AssignToDepartment(instructor, department);
department.Courses.Add(course);

// Displaying final information
studentService.DisplayPersonInfo(student);
studentService.DisplayStudentGPA(student);
instructorService.DisplayPersonInfo(instructor);
instructorService.DisplayInstructorInfo(instructor);
Console.WriteLine();


// Problem 7 with OOPs

// Creating few balls with all colors
Color redColor = new Color(255, 0, 0);
Color greenColor = new Color(0, 255, 0);
Color blueColor = new Color(0, 0, 255);

Ball redBall = new Ball(10, redColor);
Ball greenBall = new Ball(15, greenColor);
Ball blueBall = new Ball(20, blueColor);

// Throw the balls around
redBall.Throw();
redBall.Throw();
greenBall.Throw();
blueBall.Throw();
blueBall.Throw();
blueBall.Throw();

// Pop them around and try to throw it again
redBall.Pop();
blueBall.Pop();
blueBall.Throw();
redBall.Throw();

// Print out the number of times that the ball has been thrown
Console.WriteLine($"Red ball throw count: {redBall.GetThrowCount()}");
Console.WriteLine($"Green ball throw count: {greenBall.GetThrowCount()}");
Console.WriteLine($"Blue ball throw count: {blueBall.GetThrowCount()}");

// Hence, the throw count for blue and red balls doesn't increase as they were popped in between so the throw count doesn't increment for them.







