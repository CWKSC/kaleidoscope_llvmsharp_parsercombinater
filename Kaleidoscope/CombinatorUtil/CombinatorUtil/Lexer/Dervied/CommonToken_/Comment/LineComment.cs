using CombinatorUtil.Lexer.Dervied.CommonToken_;
using CombinatorUtil.Lexer.Expect_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied.CommonToken_.Comment;

public class LineComment : LexerCombinator
{

    public string start;
    public LineComment(string start) => this.start = start;
    public static LineComment New(string start = "//") => new(start);

    public override ASTNode? Parsing(ParsingContext context) =>
        And.New(
            ExpectChars.New(start),
            RegexExpectChars.New(@"[^\r\n]+"),
            NextLine.New()
        ).Parsing(context);

}