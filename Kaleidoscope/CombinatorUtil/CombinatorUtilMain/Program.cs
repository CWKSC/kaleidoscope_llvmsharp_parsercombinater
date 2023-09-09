using CombinatorUtil;
using CombinatorUtil.Expect_;
using CombinatorUtil.Lexer.Dervied;
using CombinatorUtil.Lexer.Dervied.CommonToken_.Literal_;
using CombinatorUtil.Parser.Dervied.CommonToken;
using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;
using ListTreeUtil.Extension;
using Util;

// Test function //
static ASTNode? Test(Combinator combinator, LinkedList<ASTNode> list)
{
    var context = ParsingContext.New(list);
    var result = combinator.Parsing(context);
    Console.WriteLine(result?.ToStr(new()));
    Console.WriteLine();
    return result;
}


// Expect a b c //
var abc = And.New(
    Expect.New(Node.New('a')),
    Expect.New(Node.New('b')),
    Expect.New(Node.New('c'))
);
Test(abc, LinkedList.New<ASTNode>(
    Node.New('a'),
    Node.New('b'),
    Node.New('c')
));


// Line Comment //
var lineComment = AroundMany.New(
    Expect.New(Node.New("//")),
    ExpectAny.New(),
    Expect.New(Node.New("\n"))
);
Test(lineComment, LinkedList.New<ASTNode>(
    Node.New("//"),
    Node.New(" some word "),
    Node.New(" here inside "),
    Node.New(" line comment ! "),
    Node.New("\n")
));


// Bracket matching //
var bracket = LateInit.New();
bracket.combinator = AroundMany.New(
    Expect.New(Node.New("(")),
    bracket,
    Expect.New(Node.New(")"))
);
Test(bracket, LinkedList.New<ASTNode>(
    Node.New("("),
        Node.New("("),
        Node.New(")"),
        Node.New("("),
        Node.New(")"),
    Node.New(")")
));
Test(bracket, LinkedList.New<ASTNode>(
    Node.New("("),
        Node.New("("),
        Node.New(")"),
        Node.New("("),
            Node.New("("),
            Node.New(")"),
            Node.New("("),
                Node.New("("),
                    Node.New("("),
                    Node.New(")"),
                Node.New(")"),
            Node.New(")"),
            Node.New("("),
            Node.New(")"),
        Node.New(")"),
        Node.New("("),
        Node.New(")"),
    Node.New(")")
));


// Integer Literal //
var integerLiteral = Integer.New();

Test(integerLiteral, new LinkedList<ASTNode>()
{
    Node.New('4'), Node.New('2')
});


// Float Literal //
var floatLiteral = Float.New();

Test(floatLiteral, new LinkedList<ASTNode>()
{
    Node.New('1'), Node.New('2'), Node.New('.'), Node.New('3'), Node.New('4')
});


// String Literal //
var stringLiteral = StringLiteral.New();
Test(stringLiteral, new LinkedList<ASTNode>()
{
    Node.New('\"'), Node.New('h'), Node.New('e'), Node.New('l'), Node.New('l'), Node.New('o'), Node.New(' '), Node.New('w'), Node.New('o'), Node.New('r'), Node.New('l'), Node.New('d'), Node.New('!'), Node.New('\"')
});


// Common Lexer //
var commonLexer = CommonLexer.New();
Test(commonLexer, @"
extern sin(x)
extern putchard(char)

// it is comment

func foo(a, b) {
    return a + sin b
}

main {
    var a: int32 = 42
    if (x > y) {
        foo(1, a + 2 * 5)
    } else {
        foo(6 - 7 / 9, -1 + -2)
    }
    for (int i = 0; i < 42; i++){

    }
    return 42;
}".ToNodeOrList());


// Get list args value //
{
    var tagger = new Tagger();
    var argsList = AroundMany.New(
        ExpectString.New("("),
        TagRepeat.New(tagger, Identifier.New(), "args"),
        ExpectString.New(")")
    );

    Test(argsList, new LinkedList<ASTNode>(){
        Node.New("("), Node.New("ab1"), Node.New("cd2"), Node.New("ef3"), Node.New(")")
    });
    var list = tagger.GetTagRepeat("args");

    Console.Write("args:");
    foreach (var arg in list)
    {
        Console.Write($" {arg}");
    }
    Console.WriteLine();
}



