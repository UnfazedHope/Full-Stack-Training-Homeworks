// See https://aka.ms/new-console-template for more information

using Assignment4;

// Practice working with Generics

// Problem 1

MyStack<int> stack = new MyStack<int>();

stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);

Console.WriteLine("Count: " + stack.Count()); // count -> 4

Console.WriteLine("Pop: " + stack.Pop()); // pops 4
Console.WriteLine("Pop: " + stack.Pop()); // pops 3

Console.WriteLine("Count: " + stack.Count());  // count -> 2
Console.WriteLine();

// Problem 2

MyList<int> myList = new MyList<int>();

myList.Add(1);
myList.Add(2);
myList.Add(3);
myList.Add(4);

Console.WriteLine("List Contains 3: " + myList.Contains(3));                   // Output -> True

Console.WriteLine("Element at index 1: " + myList.Find(1));                      // Output -> 2

myList.InsertAt(5, 2);
Console.WriteLine("Element at index 2 after insertion: " + myList.Find(2));      // Output -> 5

myList.DeleteAt(2);
Console.WriteLine("Element at index 2 after deletion: " + myList.Find(2));       // Output -> 3

myList.Remove(0);
Console.WriteLine("Element at index 0 after removal: " + myList.Find(0));        // Output -> 2

myList.Clear();
Console.WriteLine("Count of elements after clearing: " + myList.Contains(3));  // Output -> False
Console.WriteLine();

// Problem 3

var personRepository = new GenericRepository<Person>();

var person1 = new Person { Id = 1, Name = "Fred", Salary = 60000 };
var person2 = new Person { Id = 2, Name = "Antra", Salary = 100000 };
var person3 = new Person { Id = 3, Name = "Vishal", Salary = 80000 };
var person4 = new Person { Id = 4, Name = "Alan", Salary = 70000 };

personRepository.Add(person1);
personRepository.Add(person2);
personRepository.Add(person3);
personRepository.Add(person4);
personRepository.Save();

var allPersons = personRepository.GetAll();

foreach (var person in allPersons)
{
    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Salary: {person.Salary}");
}
Console.WriteLine();
var personById = personRepository.GetById(1);
Console.WriteLine($"Person retrieved by Id 1: Name: {personById.Name}, Salary: {personById.Salary}");

personRepository.Remove(person1);
personRepository.Save();
Console.WriteLine();

allPersons = personRepository.GetAll();
Console.WriteLine("Persons after removing person1:");
foreach (var person in allPersons)
{
    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Salary: {person.Salary}");
}

