namespace Assignment3;

public class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    // Constructor
    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    // Pop the ball, setting its size to 0
    public void Pop()
    {
        size = 0;
    }

    public void Throw()
    {
        if (size > 0)                             // != also works but size is +ve
        {
            throwCount++;
        }
    }
    
    public int GetThrowCount()
    {
        return throwCount;
    }
}