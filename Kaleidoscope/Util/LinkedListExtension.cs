namespace Util;

public static class LinkedListExtension
{

    public static void ReplaceBy<T>(this LinkedList<T> list, LinkedList<T> replace)
    {
        list.Clear();
        foreach (T item in replace) { list.AddLast(item); }
    }

    public static void Add<T>(this LinkedList<T> list, T value)
    {
        list.AddLast(value);
    }


}

public static class LinkedList
{
    public static LinkedList<T> New<T>(params T[] values) => new(values);

}