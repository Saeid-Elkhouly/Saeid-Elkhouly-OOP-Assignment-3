namespace Generics;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException(
                "Page number and page size must be greater than 0.");
        }

        int start = (pageNumber - 1) * pageSize;
        int index = 0;
        int taken = 0;

        foreach (var item in collection)
        {
            if (index >= start)
            {
                yield return item;
                taken++;

                if (taken == pageSize)
                {
                    yield break;
                }
            }

            index++;
        }
    }
    public static T GetById<T>(this IEnumerable<T> collection, int id) where T : IHasId
    {
        foreach (var item in collection)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default!;
    }
     public static IEnumerable<T> ToIdDictionary<T>(this IEnumerable<T> collection) where T : IHasId
    {
        var dictionary = new Dictionary<int, T>();

        foreach (var item in collection)
        {
            dictionary.TryAdd(item.Id, item);
        }

        return dictionary.Values;
    }
}