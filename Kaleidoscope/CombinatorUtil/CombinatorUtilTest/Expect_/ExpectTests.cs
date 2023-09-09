using CombinatorUtil;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Expect_;

[TestClass()]
public class ExpectTests
{

    [TestMethod()]
    public void Normal1_Node_string()
    {
        var expectCombinator = Expect.New(Node.New("string here"));
        var result = TestTool.ApplyCombinator(expectCombinator, Node.New("string here"));
        Assert.IsNotNull(result);

        var expect = Node.New("string here");
        Console.Write(result!.ToStr(new()));
        Assert.AreEqual(expect, result);
    }

    [TestMethod()]
    public void Normal2_Node_char()
    {
        var expectCombinator = Expect.New(Node.New('c'));
        var result = TestTool.ApplyCombinator(expectCombinator, Node.New('c'));
        Assert.IsNotNull(result);

        var expect = Node.New('c');
        Console.Write(result!.ToStr(new()));
        Assert.AreEqual(expect, result);
    }

    [TestMethod()]
    public void Normal3_Node_int()
    {
        var expectCombinator = Expect.New(Node.New(42));
        var result = TestTool.ApplyCombinator(expectCombinator, Node.New(42));
        Assert.IsNotNull(result);

        var expect = Node.New(42);
        Console.Write(result!.ToStr(new()));
        Assert.AreEqual(expect, result);
    }

    [TestMethod()]
    public void Normal4_position()
    {
        var expectCombinator = Expect.New(Node.New(42));
        var context = ParsingContext.New(new LinkedList<ASTNode>() {
            Node.New(42), Node.New(43), Node.New(44)
        });

        var result1 = expectCombinator.Parsing(context);
        Assert.IsNotNull(result1);
        Assert.AreEqual(Node.New(42), result1);
        Assert.AreEqual(2, context.list.Count);
        Assert.AreEqual(Node.New(43), context.current!.Value);

        var result2 = expectCombinator.Parsing(context);
        Assert.IsNull(result2);
        Assert.AreEqual(2, context.list.Count);
        Assert.AreEqual(Node.New(43), context.current!.Value);
    }

}
