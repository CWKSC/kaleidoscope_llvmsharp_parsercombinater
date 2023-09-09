using ListTreeUtil;

namespace CombinatorUtil.Misc;

public class AsNewContext : Combinator
{

    public Combinator from;
    public Combinator to;
    public AsNewContext(Combinator from, Combinator to)
    {
        this.from = from;
        this.to = to;
    }
    public static AsNewContext New(Combinator from, Combinator to) => new(from, to);
    public static AsNewContext<T> New<T>(Combinator from, Combinator to) where T : ASTNode => new(from, to);


    public override ASTNode? Parsing(ParsingContext context)
    {
        var fromResult = from.Parsing(context);
        if (fromResult is not LList<ASTNode> llist)
        {
            throw new InvalidOperationException("[OperatorAssociate] combinator should return LList<T>");
        }
        var newContext = ParsingContext.New(context, llist.list);
        return to.Parsing(newContext);
    }

}



public class AsNewContext<T> : Combinator
    where T : ASTNode
{

    public Combinator from;
    public Combinator to;
    public AsNewContext(Combinator from, Combinator to)
    {
        this.from = from;
        this.to = to;
    }

    public override T? Parsing(ParsingContext context)
    {
        var fromResult = from.Parsing(context);
        if (fromResult is not LList<ASTNode> llist)
        {
            throw new InvalidOperationException("[OperatorAssociate] combinator should return LList<T>");
        }
        var newContext = ParsingContext.New(context, llist.list);
        var result = to.Parsing(newContext);
        if (result is not T resultT) throw new Exception();
        return resultT;
    }

}
