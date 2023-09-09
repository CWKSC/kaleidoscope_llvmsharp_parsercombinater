using CombinatorUtil;
using CombinatorUtil.Expect_;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Expect_;

[TestClass()]
public class ExpectAnyBackwardTests
{

    [TestMethod()]
    public void Normal1()
    {
        var expectCombinator = ExpectAnyBackward.New();
        var context = ParsingContext.New(new LinkedList<ASTNode>() {
            Node.New(42), Node.New('c'), Node.New("string")
        });

        var result1 = expectCombinator.Parsing(context);
        Assert.IsNull(result1);
        Assert.AreEqual(3, context.list.Count);

        context.current = context.list.First!.Next;

        var result2 = expectCombinator.Parsing(context);
        Assert.IsNotNull(result2);
        Assert.AreEqual(Node.New(42), result2);
        Assert.AreEqual(2, context.list.Count);
        Assert.AreEqual(Node.New('c'), context.current!.Value);

        var result3 = expectCombinator.Parsing(context);
        Assert.IsNull(result3);
        Assert.AreEqual(2, context.list.Count);
        Assert.AreEqual(Node.New('c'), context.current!.Value);

    }

}