// See https://aka.ms/new-console-template for more information

// Assignment 1(C#) - Day 1
// I have used single cs file for this assignment(ran all the code separately), will use multiple cs files for Assignment 3
/*
 
Test your Knowledge
 
1]  A person’s telephone number - string
    A person’s height - float or double
    A person’s age - int
    A person’s gender (Male, Female, Prefer Not To Answer) - string, but if constrained to a numeric type, you could map each gender to a number(0,1 & 2) - int/enum
    A person’s salary - decimal
    A book’s ISBN - string
    A book’s price - decimal
    A book’s shipping weight - float or double
    A country’s population - long
    The number of stars in the universe - ulong, but if it's larger than this range then we can use BigInteger
    The number of employees in each of the small or medium businesses in the United Kingdom - int
    
2]  Difference between Value Type vs. Reference Type :-

    i) Value type will directly hold the value while reference type will hold the memory address or reference for the value. 
    ii) Value types are stored in stack memory and reference types are stored in heap memory. 
    iii) Value type will not be collected by garbage collector but reference type will be collected by garbage collector. 
    iv) The value type can be created by struct or enum while reference type can be created by class, interface, delegate or array.
    v) Value type can not accept any null values while reference types can accept null values.
    
    Boxing is conversion of value type to reference type. 
    Unboxing is conversion of reference type to value type. 
    
3]  Managed resources are resources that are handled by the .NET runtime's garbage collector, such as memory allocated for .NET objects.
    Unmanaged resources are resources that the garbage collector doesn't manage, such as file handles, database connections, and network sockets; these require explicit cleanup through code, typically using Dispose method from IDisposable interface.

4]  The purpose of the Garbage Collector in .NET is to automatically manage memory by reclaiming unused objects, thereby preventing memory leaks and optimizing memory usage. 
    It frees developers from manually deallocating memory, enhancing application stability and performance.
    
*/



//Playing with Console App

Console.Write("Enter your favorite color: ");
string favoriteColor = Console.ReadLine();

Console.Write("Enter your astrology sign: ");
string astrologySign = Console.ReadLine();

Console.Write("Enter your street address number: ");
string streetAddressNumber = Console.ReadLine();

string hackerName = $"{favoriteColor}{astrologySign}{streetAddressNumber}";

Console.WriteLine($"Your hacker name is {hackerName}");



//Practice number sizes and ranges

// 1st program

Console.WriteLine("sbyte:");
Console.WriteLine($"Size: {sizeof(sbyte)} bytes");
Console.WriteLine($"Min Value: {sbyte.MinValue}");
Console.WriteLine($"Max Value: {sbyte.MaxValue}\n");

Console.WriteLine("byte:");
Console.WriteLine($"Size: {sizeof(byte)} bytes");
Console.WriteLine($"Min Value: {byte.MinValue}");
Console.WriteLine($"Max Value: {byte.MaxValue}\n");

Console.WriteLine("short:");
Console.WriteLine($"Size: {sizeof(short)} bytes");
Console.WriteLine($"Min Value: {short.MinValue}");
Console.WriteLine($"Max Value: {short.MaxValue}\n");

Console.WriteLine("ushort:");
Console.WriteLine($"Size: {sizeof(ushort)} bytes");
Console.WriteLine($"Min Value: {ushort.MinValue}");
Console.WriteLine($"Max Value: {ushort.MaxValue}\n");

Console.WriteLine("int:");
Console.WriteLine($"Size: {sizeof(int)} bytes");
Console.WriteLine($"Min Value: {int.MinValue}");
Console.WriteLine($"Max Value: {int.MaxValue}\n");

Console.WriteLine("uint:");
Console.WriteLine($"Size: {sizeof(uint)} bytes");
Console.WriteLine($"Min Value: {uint.MinValue}");
Console.WriteLine($"Max Value: {uint.MaxValue}\n");

Console.WriteLine("long:");
Console.WriteLine($"Size: {sizeof(long)} bytes");
Console.WriteLine($"Min Value: {long.MinValue}");
Console.WriteLine($"Max Value: {long.MaxValue}\n");

Console.WriteLine("ulong:");
Console.WriteLine($"Size: {sizeof(ulong)} bytes");
Console.WriteLine($"Min Value: {ulong.MinValue}");
Console.WriteLine($"Max Value: {ulong.MaxValue}\n");

Console.WriteLine("float:");
Console.WriteLine($"Size: {sizeof(float)} bytes");
Console.WriteLine($"Min Value: {float.MinValue}");
Console.WriteLine($"Max Value: {float.MaxValue}\n");

Console.WriteLine("double:");
Console.WriteLine($"Size: {sizeof(double)} bytes");
Console.WriteLine($"Min Value: {double.MinValue}");
Console.WriteLine($"Max Value: {double.MaxValue}\n");

Console.WriteLine("decimal:");
Console.WriteLine($"Size: {sizeof(decimal)} bytes");
Console.WriteLine($"Min Value: {decimal.MinValue}");
Console.WriteLine($"Max Value: {decimal.MaxValue}\n");

 
// 2nd program

Console.Write("Enter the number of centuries: ");
int centuries = int.Parse(Console.ReadLine());
int years = centuries * 100;
long days = (long)(years * 365.24);
long hours = days * 24;
long minutes = hours * 60;
long seconds = minutes * 60;
long milliseconds = seconds * 1000;
long microseconds = milliseconds * 1000;
decimal nanoseconds = microseconds * 1000m;  // will use decimal to handle very large number

Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");


//Controlling Flow and Converting Types 

/*
 
Test your Knowledge

1] When we divide an int variable by 0, we get DivideByZeroException exception at runtime.

2] When we divide a double variable by 0, it results in Infinity or -Infinity. If we divide 0.0/0.0 we get NaN(Not a Number). 

3] If we use checked() which will check for overflow, then we get OverflowException. Otherwise, it wraps around to the minimum or maximum value of 'int' type.

4] x=y++ , This is a post-increment operation where, y is first assigned to x and then y is incremented by 1.
   x=++y , This is a pre-increment operation where, y is first incremented by 1 and then the updated value of y is assigned to x.

5] break - Terminates the loop immediately and transfers control to the statement following the loop.
   continue - Skips the remaining code in the current iteration and proceeds with the next iteration of the loop.
   return - Exits the method in which the loop is contained, thereby terminating the loop and the method execution.

6] The three parts of a 'for' statement are: initialization(initializer), condition, and iteration(iterator).
   Only the condition part is required; the initializer and iterator parts can be omitted, but the semicolons should be there.

7] = operator,  This is the assignment operator, which assigns the value on the right to the variable on the left.
   == operator, This is the equality operator, which compares the values on both sides and returns true if they are equal else returns false.

8] Yes, this statement will compile. It represents an infinite loop as the condition is always true.

9] In a switch expression, the underscore '_' is used as a discard pattern, which matches any value not matched by previous cases, basically acting as a default case.

10] An object must implement the 'IEnumerable' interface to be enumerated over by using the foreach statement.

*/

// Practice loops and operators

// 1st program

for (int i=1; i<=100;i++)
{
    if (i%3 == 0 && i%5 == 0)                       //need to check this condition first then the other ones
    {
        Console.WriteLine("fizzbuzz");
    }
    if (i%3 == 0)
    {
        Console.WriteLine("fizz");
    }
    else if (i%5 == 0)
    {
        Console.WriteLine("buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
}

// int max = 500;
// for (byte i = 0; i < max; i++)
// {
//     Console.WriteLine(i);
// }

// The above code can be fixed by replacing 'byte' with 'int', since byte's range is 0 to 255, therefore
// the loop is running infinitely as it wraps and starts from 0 again. This cycle continues indefinitely.



// 2nd program

int rows = 5;
for (int i=1; i<=rows; i++)
{
    //to print spaces
    for (int j=rows; j>i; j--)
    {
        Console.Write(" ");
    }
    // to print stars
    for (int k=1; k<=(2*i-1);k++)                       // ensures that the number of stars increases by 2 for each subsequent row
    {
        Console.Write("*");
    }
    // move to operate for next line
    Console.WriteLine();
}



// 3rd program

int correctNumber = new Random().Next(3) + 1;

Console.Write("Guess a number between 1 and 3: ");
int guessedNumber = int.Parse(Console.ReadLine());

if (guessedNumber < 1 || guessedNumber > 3)
{
    Console.WriteLine("Your guess is outside the range of valid numbers.");
}
else if (guessedNumber < correctNumber)
{
    Console.WriteLine("Your guess is too low.");
}
else if (guessedNumber > correctNumber)
{
    Console.WriteLine("Your guess is too high.");
}
else
{
    Console.WriteLine("You guessed the correct number!!");
}



// 4th program

DateTime birthDate = new DateTime(2001, 01, 24);

DateTime currentDate = DateTime.Today;
int daysOld = (currentDate - birthDate).Days;

Console.WriteLine($"The person is {daysOld} days old.");

int daysToNextAnniversary = 10000 - (daysOld % 10000);
DateTime nextAnniversaryTenK = currentDate.AddDays(daysToNextAnniversary);

Console.WriteLine($"The next 10,000-day anniversary is on: {nextAnniversaryTenK.ToShortDateString()}"); // omits time



// 5th program

DateTime currentTime = DateTime.Now;
int currentHour = currentTime.Hour;

// Greet the user based on the current time(using 24 hrs rule)
if (currentHour >= 5 && currentHour < 12)
{
    Console.WriteLine("Good Morning");
}
if (currentHour >= 12 && currentHour < 17)
{
    Console.WriteLine("Good Afternoon");
}
if (currentHour >= 17 && currentHour < 20)
{
    Console.WriteLine("Good Evening");
}
if ((currentHour >= 20 && currentHour <= 23) || (currentHour >= 0 && currentHour < 5))
{
    Console.WriteLine("Good Night");
}



// 6th program

for (int inc=1; inc<=4; inc++)
{
    for (int i=0; i<=24; i+=inc)
    {
        // using console.write which will print them in same line
        Console.Write(i);
        if (i+inc > 24)
        {
            break;
        }
        Console.Write(",");
    }
    Console.WriteLine();
}















