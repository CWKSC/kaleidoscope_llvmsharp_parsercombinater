using PrinterUtil;
using System.Collections;

namespace ListTreeUtil;

public interface ILList
{

}

public class LList<T> : ASTNode, IEnumerable<T>, ILList
{

    public List<T> list = new();
    public List<T> Get() { return list; }

    public LList() { }

    public LList(List<T> list) => this.list = list;

    public void Add(T value) => list.Add(value);

    public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public T this[int i]
    {
        get { return list[i]; }
        set { list[i] = value; }
    }

    public override string ToStr(Printer printer)
    {
        string result = "";
        printer.IncreaseIndentExceptFirstTime();
        result += "↘".ToStr(printer) + "\n";
        foreach (var item in list)
        {
            if (item is IToStr iToStr)
            {
                result += iToStr.ToStr(printer);
            }
            else
            {
                result += item?.ToString() ?? "(null node)".ToStr(printer);
            }
            result += "\n";
        }
        result += "↙".ToStr(printer);
        printer.DecreaseIndent();
        return result;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not LList<T> other) return false;
        var otherList = other.list;
        if (list.Count != otherList.Count) return false;

        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            var otherItem = otherList[i];
            if (item == null) return false;
            if (!item.Equals(otherItem)) return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(list);
    }

}