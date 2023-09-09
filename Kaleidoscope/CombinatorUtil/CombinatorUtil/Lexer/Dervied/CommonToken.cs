using CombinatorUtil.Ignore_;
using CombinatorUtil.Lexer.Dervied.CommonToken_;
using CombinatorUtil.Lexer.Dervied.CommonToken_.Comment;
using CombinatorUtil.Lexer.Dervied.CommonToken_.Literal_;
using ListTreeUtil;

namespace CombinatorUtil.Lexer.Dervied;

public class CommonToken : LexerCombinator
{
    public static CommonToken New() => new();

    public override ASTNode? Parsing(ParsingContext context) =>
        Or.New(
            Ignore.New(Spaces.New()),
            Ignore.New(NextLine.New()),
            Ignore.New(Tabs.New()),
            Ignore.New(LineComment.New()),
            Semicolon.New(),
            Colon.New(),
            Bracket.New(),
            Comma.New(),
            Equal.New(),
            Literal.New(), // before ArithmeticOperator
            ArithmeticOperator.New(),
            LogicOperator.New(),
            Identifier.New()
        ).Parsing(context);

}
