using CombinatorUtil.Ignore_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied;

public class CommonLexer : LexerCombinator
{

    LexerCombinator token;

    public CommonLexer(LexerCombinator? token = null)
    {
        this.token = token ?? CommonToken.New();
    }
    public static CommonLexer New(LexerCombinator? token = null) => new(token);

    public override LList<ASTNode>? Parsing(ParsingContext context) =>
        CleanIgnore.New(Many.New(token)).Parsing(context);


}