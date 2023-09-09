using ListTreeUtil;

namespace CombinatorUtil;

public class TagRepeat : Combinator
{

    public Tagger tagger;
    public Combinator combinator;
    public string tag;

    public TagRepeat(Tagger tagger, Combinator combinator, string tag)
    {
        this.tagger = tagger;
        this.combinator = combinator;
        this.tag = tag;
    }
    public static TagRepeat New(Tagger tagger, Combinator combinator, string tag) => new(tagger, combinator, tag);

    public override ASTNode? Parsing(ParsingContext context)
    {
        var result = combinator.Parsing(context);
        if (result == null) return null;
        tagger.TagRepeat(result, tag);
        return result;
    }

}
