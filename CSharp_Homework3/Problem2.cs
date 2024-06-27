namespace Assignment3;

public class Problem2
{
   public int Fibonacci(int n)
   {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        // Fibonacci logic
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}