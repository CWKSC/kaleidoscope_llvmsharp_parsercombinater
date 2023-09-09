using CombinatorUtil.Parser.Expect_;
using CombinatorUtil.Recover;
using ListTreeUtil;
using Util;

var linkedList = new LinkedList<ASTNode>()
{
    Node.New("b"), Node.New("c")
};

var combinator = RecoverIfNull.New(ExpectString.New("a"));
var result = combinator.Parsing(new(linkedList));

Console.WriteLine(result!.ToStr(new()));

