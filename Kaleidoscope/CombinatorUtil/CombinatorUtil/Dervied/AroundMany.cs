using CombinatorUtil.AST;

namespace CombinatorUtil;

public class AroundMany : Combinator
{

    public Combinator start;
    public Combinator combinator;
    public Combinator end;

    public AroundMany(Combinator start, Combinator combinator, Combinator end)
    {
        this.start = start;
        this.combinator = combinator;
        this.end = end;
    }
    public static AroundMany New(Combinator start, Combinator combinator, Combinator end) => new(start, combinator, end);


    public override AroundManyAST? Parsing(ParsingContext context)
    {
        var startAST = start.Parsing(context);
        if (startAST == null) return null;

        var untilAST = Until.New(combinator, end).Parsing(context);
        if (untilAST == null) return null;
        var manyAST = untilAST.many;
        var endAST = untilAST.end;

        return new(startAST, manyAST, endAST);
    }

}
