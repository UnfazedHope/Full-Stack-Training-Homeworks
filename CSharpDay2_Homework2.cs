// See https://aka.ms/new-console-template for more information

// Assignment 2(C#) - Day 1
// I have used single cs file for this assignment(ran all the code separately), will use multiple cs files for Assignment 3

/*

Test your Knowledge

1] String - When dealing with immutable text data where modifications are infrequent or minimal we can use String.
   StringBuilder - When we need numerous string manipulations we can use StringBuilder as it is mutable.

2] The base class for all arrays is System.Array in C#.

3] We can sort array in C# using 'Arrays.Sort()' method.

4] We can use 'Length' property(array.Length) to get the total number of elements in an array.

5] No, we can't store multiple data types in System.Array as it is Strongly typed which means all the data type inside the array should be same.

6] System.Array.CopyTo() - This method copies the elements of the current array to another existing array starting at a particular index in the target array.
   System.Array.Clone() - This method creates a shallow copy of the array and returns a new array object containing the same elements with same length and type as the original.

*/

using System.Text.RegularExpressions;

// Practice Arrays

// 1st Program

int[] Array1 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int[] Array2 = new int[Array1.Length];

for (int i = 0; i<Array1.Length; i++)
{
    Array2[i] = Array1[i];
}

Console.WriteLine("Original Array values:");

for(int i = 0; i<Array1.Length; i++)
{
    Console.Write(Array1[i] + " ");
}

Console.WriteLine("\n\nCopied Array values:");

for(int i = 0; i<Array2.Length; i++)
{
    Console.Write(Array2[i] + " ");
}



// 2nd Program

List<string> itemList = new List<string>();
string userInput;

while (true)
{
    Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
    userInput = Console.ReadLine();

    // Clear list using Clear() method
    if (userInput == "--")
    {
        itemList.Clear();
        Console.WriteLine("List cleared.");
    }
    // Add item to the list using Add() method
    else if (userInput.StartsWith("+"))
    {
        string itemToAdd = userInput.Substring(1).Trim();
        itemList.Add(itemToAdd);
        Console.WriteLine($"Added: {itemToAdd}");
    }
    // Remove item from the list using Remove() method
    else if (userInput.StartsWith("-"))
    {
        string itemToRemove = userInput.Substring(1).Trim();
        itemList.Remove(itemToRemove);
        Console.WriteLine($"Removed: {itemToRemove}");
    }
    else
    {
        Console.WriteLine("Invalid command.");
    }

    // Display current list
    Console.WriteLine("Current list:");
    if (itemList.Count == 0)
    {
        Console.WriteLine("empty list.");
    }
    else
    {
        foreach (var item in itemList)
        {
            Console.WriteLine(item);
        }
    }
    Console.WriteLine();
}



// 3rd Program

int[] FindPrimesInRange(int startNum, int endNum)
{
   List<int> primes = new List<int>();

   for (int i = startNum; i <= endNum; i++)
   {
      if (IsPrime(i))
      {
         primes.Add(i);
      }
   }

   return primes.ToArray();
}

bool IsPrime(int n)
{
   if (n <= 1)
      return false;
 
   // Check from 2 to n-1
   for (int i = 2; i <= n / 2; i++)
      if (n % i == 0)
         return false;
 
   return true;
}

int[] Array3 = FindPrimesInRange(2, 17);

for(int i = 0; i<Array3.Length; i++)
{
    Console.Write(Array3[i] + " ");
}



// 4th Program

Console.WriteLine("Enter the array of integers:");
string[] input = Console.ReadLine().Split();
int[] array = new int[input.Length];
for (int i = 0; i < input.Length; i++)
{
   array[i] = int.Parse(input[i]);
}

// Number of rotations
Console.WriteLine("Enter the number of rotations:");
int k = int.Parse(Console.ReadLine());

// Sum array
int[] sum = new int[array.Length];

// Performing rotations 'k' times
for (int r = 1; r <= k; r++)
{
   int[] rotatedArray = RotateRight(array, r);
   
   for (int i = 0; i < array.Length; i++)
   {
      sum[i] += rotatedArray[i];
   }
   
   Console.WriteLine($"Rotated {r} times: {string.Join(" ", rotatedArray)}");
}

Console.WriteLine($"Sum array: {string.Join(" ", sum)}");

//rotating right using element at position I goes to position (I + r) % n logic
int[] RotateRight(int[] array, int r)
{
   int n = array.Length;
   int[] rotated = new int[n];
        
   for (int i = 0; i < n; i++)
   {
      rotated[(i + r) % n] = array[i];
   }

   return rotated;
}

// 5th Program

int[] numbers5 = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
int count = 1;
int longestNum = numbers5[0];
int longestCount = 1;

for (int i = 1; i < numbers5.Length; i++)
{
   if (numbers5[i] != numbers5[i-1])
   {
      count = 1;
   }
   else
   {
      count++;
   }
   if (count > longestCount)
   {
      longestCount = count;
      longestNum = numbers5[i];
   }
}

//Print the longest sequence
for (int i = 0; i < longestCount; i++)
{
   Console.Write(longestNum + " ");
}
Console.WriteLine();



// 6th Program

int[] numbers6 = { 7 ,7, 7, 0, 2, 2, 2, 0, 10, 10, 10 };
int mostFrequent = numbers6[0];
int maxCount = 1;

for (int i = 0; i < numbers6.Length; i++)
{
   int currentCount = 0;

   for (int j = 0; j < numbers6.Length; j++)
   {
      if (numbers6[j] == numbers6[i])
      {
         currentCount++;
      }
   }

   if (currentCount > maxCount)
   {
      maxCount = currentCount;
      mostFrequent = numbers6[i];
   }
}

Console.WriteLine($"Most frequent number in the array = {mostFrequent}");



// Practice String

// 1st Program

// Method - 1 - Convert the string to char array, reverse it, then convert it to string again

string s = Console.ReadLine();
char[] charArray = s.ToCharArray();

Array.Reverse(charArray);

string reversed = new string(charArray);

Console.WriteLine(reversed);


// Method - 2 - Print the letters of the string in back direction (from the last to the first) in a for-loop


string s1 = Console.ReadLine();

for (int i = s1.Length - 1; i >= 0; i--)
{
   Console.Write(s1[i]);
}
Console.WriteLine();



// 2nd Program

//Method 1
string s2 = "The quick brown fox jumps over the lazy dog /Yes! Really!!!/";    
string result = String.Join(" ", s2.Split('.', ' ').Reverse());
Console.WriteLine(result);

// Method 2 - using Regex


string s2_2 = "The quick brown fox jumps over the lazy dog /Yes! Really!!!/";
// Given Pattern
string pattern1 = @"([.,:;=()&[\]\""'\\/!? ]+)";
        
// Split the input based on the pattern 
string[] parts = Regex.Split(s2_2, pattern1);

// Extract words and reverse them
List<string> words = new List<string>();
foreach (string part in parts)
{
   if (!Regex.IsMatch(part, pattern1))
   {
      words.Add(part);
   }
}
words.Reverse();

// Again writing/creating the required sentence
int wordIndex = 0;
for (int i = 0; i < parts.Length; i++)
{
   if (!Regex.IsMatch(parts[i], pattern1))
   {
      parts[i] = words[wordIndex++];
   }
}

Console.WriteLine(string.Join("", parts));


// 3rd Program

//using System.Text.RegularExpressions;

string s3 = "Hi,exe? ABBA! Hog fully a string: ExE. Bob";

// Use a regex pattern to match words
string pattern = @"\b\p{L}+\b";
MatchCollection matches = Regex.Matches(s3, pattern);

// Use a HashSet to store unique palindromes
HashSet<string> palindromes = new HashSet<string>();

foreach (Match match in matches)
{
   string word = match.Value;
   if (IsPalindrome(word))
   {
      palindromes.Add(word);
   }
}

// Print the required sorted list of palindromes
Console.WriteLine(string.Join(", ", palindromes.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ThenBy(p => p, StringComparer.Ordinal)));

// palindrome function definition
bool IsPalindrome(string word)
{
   int length = word.Length;
   for (int i = 0; i < length / 2; i++)
   {
      if (word[i] != word[length - i - 1])
      {
         return false;
      }
   }
   return true;
}



// 4th Program

var uri = new Uri("https://www.apple.com/iphone");

Console.WriteLine($"[protocol] = \"{(uri.Scheme != "http" ? uri.Scheme : "")}\"");
Console.WriteLine($"[server] = \"{uri.Host}\"");
Console.WriteLine($"[resource] = \"{uri.AbsolutePath.TrimStart('/')}\"");

