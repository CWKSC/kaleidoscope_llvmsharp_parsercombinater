using CombinatorUtil.Recover;
using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil;


public class Or : Combinator
{

    public List<Combinator> combinatorList;
    public Or(List<Combinator> combinatorList) => this.combinatorList = combinatorList;
    public static Or New(params Combinator[] combinatorList) => new(combinatorList.ToList());
    public static Or<T> New<T>(params Combinator[] combinatorList) where T : ASTNode => new(combinatorList.ToList());

    public override ASTNode? Parsing(ParsingContext context)
    {
        foreach (var combinator in combinatorList)
        {
            var node = RecoverIfNull.New(combinator).Parsing(context);
            if (node == null) continue;
            $"Match Or [{node}]".Print(new() { foregroundColor = ConsoleColor.Blue });
            return node;
        }
        return null;
    }

    public void Add(Combinator combinator)
    {
        combinatorList.Add(combinator);
    }

}

public class Or<T> : Combinator
    where T : ASTNode
{

    public List<Combinator> combinatorList;
    public Or(List<Combinator> combinatorList) => this.combinatorList = combinatorList;

    public override T? Parsing(ParsingContext context)
    {
        foreach (var combinator in combinatorList)
        {
            var node = RecoverIfNull.New(combinator).Parsing(context);
            if (node == null) continue;
            if (node is not T nodeT) throw new Exception("[Or<T>] Unexpected type");
            $"Match Or [{nodeT}]".Print(new() { foregroundColor = ConsoleColor.Blue });
            return nodeT;
        }
        return null;
    }

    public void Add(Combinator combinator)
    {
        combinatorList.Add(combinator);
    }

}

