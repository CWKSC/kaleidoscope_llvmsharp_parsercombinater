using CombinatorUtil.Node_;
using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil.Ignore_;

public class CleanIgnore : Combinator
{

    public Combinator combinator;
    public CleanIgnore(Combinator combinator) => this.combinator = combinator;
    public static CleanIgnore New(Combinator combinator) => new(combinator);

    public override LList<ASTNode>? Parsing(ParsingContext context)
    {
        var parsingResult = combinator.Parsing(context);
        if (parsingResult == null) return null;

        if (parsingResult is not IEnumerable<ASTNode> list)
        {
            "[CleanIgnore] Result not IEnumerable<ASTNode>".Print(new() { foregroundColor = ConsoleColor.Red });
            return null;
        }

        var result = new LList<ASTNode>();
        foreach (var ele in list)
        {
            if (ele is IgnoreNode) continue;
            result.Add(ele);
        }

        return result;
    }

}
