namespace Assignment4;

public class MyStack<T>
{
    private List<T> elements;

    public MyStack()
    {
        elements = new List<T>();
    }

    // Count of elements in the stack
    public int Count()
    {
        return elements.Count;
    }

    // pop an element from the stack
    public T Pop()
    {
        if (elements.Count == 0)
        {
            Console.WriteLine("The stack is empty. Pop not possible");
        }

        T item = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);

        return item;
    }

    // push an element onto the stack
    public void Push(T item)
    {
        elements.Add(item);
    }
}