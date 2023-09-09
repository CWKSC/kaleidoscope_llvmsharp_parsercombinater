using CombinatorUtil.AST;
using ListTreeUtil;

namespace CombinatorUtil;

public class Many : Combinator
{

    public Combinator combinator;
    public Many(Combinator combinator) => this.combinator = combinator;
    public static Many New(Combinator combinator) => new(combinator);

    public override ManyAST Parsing(ParsingContext context)
    {
        var result = new List<ASTNode>();
        while (context.list.Count != 0)
        {
            var node = combinator.Parsing(context);
            if (node == null) return new(result);
            result.Add(node);
        }
        return new(result);
    }

}



