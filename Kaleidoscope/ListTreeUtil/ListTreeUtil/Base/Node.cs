using PrinterUtil;

namespace ListTreeUtil;

public class Node : ASTNode
{

    public static Node<T> New<T>(T value) => new(value);

    public override string ToStr(Printer printer)
    {
        return printer.GetString("(Node)");
    }

}

public class Node<T> : Node
{

    public T value;
    public Node(T value) => this.value = value;
    public override string? ToString() => value?.ToString();

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Node<T> other) return false;
        if (other == null) return false;
        if (other.value == null && value == null) return true;
        if (value == null) return false;
        return value.Equals(other.value);
    }

    public override int GetHashCode() => value == null ? 0 : value.GetHashCode();

    public override string ToStr(Printer printer)
    {
        if (value == null)
        {
            return "(Null node) (value is null)".ToStr(printer);
        }

        if (value is IToStr valueToStr)
        {
            return valueToStr.ToStr(printer);
        }

        string? toStringResult = value.ToString();
        if (toStringResult == null)
        {
            return "(Null node) (ToString() is null)".ToStr(printer);
        }

        return toStringResult.ToStr(printer);
    }


}
