using CombinatorUtil;
using ListTreeUtil;

namespace CombinatorUtilTest.TestTool_;

public static class TestTool
{

    public static ASTNode? ApplyCombinator(Combinator combinator, LinkedList<ASTNode> list)
    {
        var context = ParsingContext.New(list);
        return combinator.Parsing(context);
    }

    public static ASTNode? ApplyCombinator(Combinator combinator, params ASTNode[] list) =>
        ApplyCombinator(combinator, new LinkedList<ASTNode>(list));

    public static (ParsingContext, ASTNode?) ApplyCombinatorWithContext(Combinator combinator, LinkedList<ASTNode> list)
    {
        var context = ParsingContext.New(list);
        var result = combinator.Parsing(context);
        return (context, result);
    }

    public static (ParsingContext, ASTNode?) ApplyCombinatorWithContext(Combinator combinator, params ASTNode[] list) =>
        ApplyCombinatorWithContext(combinator, new LinkedList<ASTNode>(list));

}
