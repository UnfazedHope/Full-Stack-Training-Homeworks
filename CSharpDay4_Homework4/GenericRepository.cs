namespace Assignment4;
 
// Acc to problem, have a type constraint on T were it should be of reference type and can be of type Entity which has one property called Id
public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private List<T> context;

    public GenericRepository()
    {
        context = new List<T>();
    }

    public void Add(T item)
    {
        context.Add(item);
    }

    public void Remove(T item)
    {
        context.Remove(item);
    }

    public void Save()
    {
        // For database this might be needed, so I left it blank 
    }

    public IEnumerable<T> GetAll()
    {
        return context;
    }

    public T GetById(int id)
    {
        foreach (var item in context)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }
}