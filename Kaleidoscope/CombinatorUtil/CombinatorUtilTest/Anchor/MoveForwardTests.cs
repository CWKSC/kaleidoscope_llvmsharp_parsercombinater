using CombinatorUtil;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Anchor;

[TestClass()]
public class MoveForwardTests
{

    [TestMethod()]
    public void Normal1()
    {
        var list = new LinkedList<ASTNode>() { Node.New("1"), Node.New("2"), Node.New("3") };
        var context = ParsingContext.New(list);

        var moveForward = MoveForward.New();
        var result = moveForward.Parsing(context);

        Assert.AreEqual(new Success(), result);
        Assert.AreEqual(context.current!.Value, Node.New("2"));
    }

    [TestMethod()]
    public void Normal2()
    {
        var list = new LinkedList<ASTNode>() { Node.New("1"), Node.New("2"), Node.New("3") };
        var context = ParsingContext.New(list);

        var moveForward = MoveForward.New();
        var result1 = moveForward.Parsing(context);
        var result2 = moveForward.Parsing(context);

        Assert.AreEqual(new Success(), result1);
        Assert.AreEqual(new Success(), result2);
        Assert.AreEqual(context.current!.Value, Node.New("3"));
    }

    [TestMethod()]
    public void NoNextNode()
    {
        var list = new LinkedList<ASTNode>() { Node.New("1"), Node.New("2"), Node.New("3") };
        var context = ParsingContext.New(list);

        var moveForward = MoveForward.New();
        var result1 = moveForward.Parsing(context);
        var result2 = moveForward.Parsing(context);
        var result3 = moveForward.Parsing(context);

        Assert.AreEqual(new Success(), result1);
        Assert.AreEqual(new Success(), result2);
        Assert.IsNull(result3);
        Assert.AreEqual(context.current!.Value, Node.New("3"));
    }

}


