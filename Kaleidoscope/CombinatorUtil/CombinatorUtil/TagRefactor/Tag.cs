using ListTreeUtil;

namespace CombinatorUtil;

public class Tag : Combinator
{

    public Tagger tagger;
    public Combinator combinator;
    public string tag;

    public Tag(Tagger tagger, Combinator combinator, string tag)
    {
        this.tagger = tagger;
        this.combinator = combinator;
        this.tag = tag;
    }
    public static Tag New(Tagger tagger, Combinator combinator, string tag) => new(tagger, combinator, tag);


    public override ASTNode? Parsing(ParsingContext context)
    {
        var result = combinator.Parsing(context);
        if (result == null) return null;
        tagger.Tag(result, tag);
        return result;
    }

}
