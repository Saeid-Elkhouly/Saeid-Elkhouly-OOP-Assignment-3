/*
Step 3 — One class for both
Write one class Store<T> with the same four methods, working on T instead of a specific type. GetById will
not compile. In Answers.md, copy the compiler error and explain in your own words why the compiler rejects
it.
*/
/*
Step 4 — Tell the compiler about Id
Create an interface IHasId with a read-only int Id. Make Student and Course implement it, and add the
constraint where T : IHasId to Store<T>. GetById now compiles. Delete StudentStore and
CourseStore — Store<Student> and Store<Course> replace them*/
/*
Step 5 — Make it fast and safe
• Replace the internal List<T> with a Dictionary<int, T> keyed by Id, so GetById does not loop.
• Add throws an exception with a clear message if an item with the same Id already exists.
• GetAll must not let the caller add or remove items in the store — choose its return type yourself.
*/
namespace Generics;

public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = [];
    
    public IReadOnlyDictionary<int, T>  Items=> _items;

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new ArgumentException("An item with the same ID already exists.");
        }
        _items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        _items.TryGetValue(id, out T? item);
        
        return item;
    }

       
    

    public bool Remove(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item.Id);
            return true;
        }
        return false;
    }
}

public interface IHasId
{
    int Id { get; }
}