using CombinatorUtil;
using CombinatorUtil.Expect_;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Expect_;

[TestClass()]
public class ExpectAnyTests
{

    [TestMethod()]
    public void Normal1()
    {
        var expectCombinator = ExpectAny.New();
        var context = ParsingContext.New(new LinkedList<ASTNode>() {
            Node.New(42), Node.New('c'), Node.New("string")
        });

        var result1 = expectCombinator.Parsing(context);
        Assert.IsNotNull(result1);
        Assert.AreEqual(Node.New(42), result1);
        Assert.AreEqual(2, context.list.Count);
        Assert.AreEqual(Node.New('c'), context.current!.Value);

        var result2 = expectCombinator.Parsing(context);
        Assert.IsNotNull(result2);
        Assert.AreEqual(Node.New('c'), result2);
        Assert.AreEqual(1, context.list.Count);
        Assert.AreEqual(Node.New("string"), context.current!.Value);

        var result3 = expectCombinator.Parsing(context);
        Assert.IsNotNull(result3);
        Assert.AreEqual(Node.New("string"), result3);
        Assert.AreEqual(0, context.list.Count);
        Assert.IsNull(context.current);

        var result4 = expectCombinator.Parsing(context);
        Assert.IsNull(result4);
    }

}