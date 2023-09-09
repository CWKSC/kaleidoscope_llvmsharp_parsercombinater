using ListTreeUtil;
using ListTreeUtil.Base;

namespace CombinatorUtil.Logic;

public class AndPair : Combinator
{

    public Combinator combinator1;
    public Combinator combinator2;

    public AndPair(Combinator combinator1, Combinator combinator2)
    {
        this.combinator1 = combinator1;
        this.combinator2 = combinator2;
    }
    public static AndPair New(Combinator combinator1, Combinator combinator2) => new(combinator1, combinator2);
    public static AndPair<T> New<T>(Combinator combinator1, Combinator combinator2) => new(combinator1, combinator2);

    public override PairNode<ASTNode, ASTNode>? Parsing(ParsingContext context)
    {
        var first = combinator1.Parsing(context);
        if (first == null) return null;

        var second = combinator2.Parsing(context);
        if (second == null) return null;

        return new PairNode<ASTNode, ASTNode>(first, second);
    }

}

public class AndPair<T> : Combinator
{

    public Combinator combinator1;
    public Combinator combinator2;

    public AndPair(Combinator combinator1, Combinator combinator2)
    {
        this.combinator1 = combinator1;
        this.combinator2 = combinator2;
    }
    public override PairNode<T, T>? Parsing(ParsingContext context)
    {
        var first = combinator1.Parsing(context);
        if (first == null) return null;
        if (first is not T firstT) return null;

        var second = combinator2.Parsing(context);
        if (second == null) return null;
        if (second is not T secondT) return null;

        return new PairNode<T, T>(firstT, secondT);
    }

}

