using CombinatorUtil.Expect_;
using CombinatorUtil.GeneralCombinator_.Node_;
using CombinatorUtil.Recover;
using ListTreeUtil;

namespace CombinatorUtil.GeneralCombinator_.Grouping.Bracket;

public class GroupBracket : Combinator
{

    public static GroupBracket New() => new();

    public override BracketAST? Parsing(ParsingContext context)
    {
        var startBracket = ExpectNodeOrListUnwarp.New(Node.New("(")).Parsing(context);
        if (startBracket == null) return null;

        var many = new LList<ASTNode>();
        var list = context.list;
        while (true)
        {
            if (!list.Any()) return null;

            // Peek Until //
            var untilNode = RecoverIfNull.New(ExpectNodeOrListUnwarp.New(Node.New(")"))).Parsing(context);
            if (untilNode != null) return new BracketAST(many.ToArray());

            // Many part //
            var anotherBracket = RecoverIfNull.New(New()).Parsing(context);
            if (anotherBracket != null)
            {
                many.Add(anotherBracket);
            }
            else
            {
                var node = ExpectAny.New().Parsing(context);
                if (node == null) return null;
                many.Add(node);
            }
        }
    }

}

