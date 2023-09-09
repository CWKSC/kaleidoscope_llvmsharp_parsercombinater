using CombinatorUtil.Expect_;
using CombinatorUtil.Recover;
using ListTreeUtil;

namespace CombinatorUtil.Dervied;

public class Spilt : Combinator
{

    public Combinator delimiter;
    public Spilt(Combinator delimiter) => this.delimiter = delimiter;
    public static Spilt New(Combinator delimiter) => new(delimiter);

    public override LList<LList<ASTNode>> Parsing(ParsingContext context)
    {
        var listlist = new LList<LList<ASTNode>>();
        while (true)
        {
            var list = new LList<ASTNode>();
            while (true)
            {
                var peek = RecoverIfNull.New(delimiter).Parsing(context);
                if (peek != null) break;

                var any = ExpectAny.New().Parsing(context);
                if (any == null)
                {
                    listlist.Add(list);
                    return listlist;
                }
                list.Add(any);
            }
            listlist.Add(list);
        }
    }

}