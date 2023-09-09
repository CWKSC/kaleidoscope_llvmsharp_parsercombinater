using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil;

public class TagN : Combinator
{

    public Tagger tagger;
    public Combinator combinator;
    public string[] tags;

    public TagN(Tagger tagger, Combinator combinator, params string[] tags)
    {
        this.combinator = combinator;
        this.tagger = tagger;
        this.tags = tags;
    }
    public static TagN New(Tagger tagger, Combinator combinator, params string[] tags) => new(tagger, combinator, tags);


    public override LList<ASTNode>? Parsing(ParsingContext context)
    {
        var node = combinator.Parsing(context);
        if (node == null) return null;
        if (node is not LList<ASTNode> list)
        {
            $"Expect LList<NodeOrList> but actual {node.GetType()}".Print(new() { foregroundColor = ConsoleColor.Yellow });
            return null;
        }
        tagger.TagN(list, tags);
        return list;
    }

}

