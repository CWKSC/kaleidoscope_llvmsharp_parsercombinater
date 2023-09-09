using ListTreeUtil;

namespace CombinatorUtil;

public abstract class Combinator
{

    public abstract ASTNode? Parsing(
        ParsingContext context
    );

}