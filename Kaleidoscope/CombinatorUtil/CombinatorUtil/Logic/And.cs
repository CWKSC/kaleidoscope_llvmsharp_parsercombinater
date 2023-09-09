using CombinatorUtil.Recover;
using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil;

public class AndBody : Combinator
{

    public List<Combinator> combinatorList;
    public AndBody(List<Combinator> combinatorList) => this.combinatorList = combinatorList;
    public static AndBody New(params Combinator[] combinatorList) => new(combinatorList.ToList());
    public static AndBody New(List<Combinator> combinatorList) => new(combinatorList);

    public override LList<ASTNode>? Parsing(ParsingContext context)
    {
        var result = new LList<ASTNode>();
        foreach (var combinator in combinatorList)
        {
            var node = combinator.Parsing(context);
            if (node == null) return null;
            result.Add(node);
        }
        $"Match And {string.Join(" ", result.Select(ele => $"[{ele}]"))}"
            .Print(new() { foregroundColor = ConsoleColor.Blue });
        return result;
    }

}

public class And : Combinator
{

    public readonly List<Combinator> combinatorList;
    public And(List<Combinator> combinatorList) => this.combinatorList = combinatorList;
    public static And New(params Combinator[] combinatorList) => new(combinatorList.ToList());
    public static And New(List<Combinator> combinatorList) => new(combinatorList);

    public override LList<ASTNode>? Parsing(ParsingContext context) =>
        (LList<ASTNode>?)RecoverIfNull.New(AndBody.New(combinatorList)).Parsing(context);

}


