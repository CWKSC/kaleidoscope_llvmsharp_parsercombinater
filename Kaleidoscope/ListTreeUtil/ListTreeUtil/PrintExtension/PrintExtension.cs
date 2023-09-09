using PrinterUtil;

namespace ListTreeUtil;

public static class PrintExtension
{

    public static Printer Print<T>(this ASTNode? node, Printer printer)
        where T : ASTNode?
    {
        if (node == null)
        {
            printer.WriteLine("(null node)");
            return printer;
        }
        if (node is not LList<T> list)
        {
            printer.WriteLine(node);
            return printer;
        }
        list.Print(printer);
        return printer;
    }

    public static Printer Print<T>(this LList<T>? list, Printer printer)
        where T : ASTNode?
    {
        if (list == null)
        {
            printer.WriteLine("(null list)");
            return printer;
        }
        printer.IncreaseIndentExceptFirstTime();
        printer.WriteLine("↘");
        foreach (T node in list)
        {
            node.Print<T>(printer);
        }
        printer.WriteLine("↙");
        printer.DecreaseIndent();
        return printer;
    }


}
