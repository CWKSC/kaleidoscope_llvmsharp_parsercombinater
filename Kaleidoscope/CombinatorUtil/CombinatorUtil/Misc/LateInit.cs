using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil;

public class LateInit : Combinator
{

    public Combinator? combinator = null;
    public static LateInit New() => new();

    public override ASTNode? Parsing(ParsingContext context)
    {
        if (combinator == null)
        {
            "[LateInit] Havn't init combinator".Print(new() { foregroundColor = ConsoleColor.Red });
            return null;
        }
        return combinator.Parsing(context);
    }

}



