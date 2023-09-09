using CombinatorUtil.Anchor;
using CombinatorUtil.Expect_;
using CombinatorUtil.Recover;
using ListTreeUtil;

namespace CombinatorUtil.Dervied;

public class SpiltUntil : Combinator
{

    public Combinator until;
    public SpiltUntil(Combinator until) => this.until = until;
    public static SpiltUntil New(Combinator combinator) => new(combinator);


    public override LList<ASTNode> Parsing(ParsingContext context)
    {
        var result = new LList<ASTNode>();
        while (true)
        {
            var untilNode = RecoverAny.New(until).Parsing(context);
            if (untilNode != null) break;
            var anyNode = ExpectAny.New().Parsing(context);
            result.Add(anyNode!);
            var isEnd = IsEnd.New().Parsing(context);
            if (isEnd.value) break;
        }
        return result;
    }

}

