using CombinatorUtil;
using CombinatorUtil.Dervied;
using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Dervied;

[TestClass()]
public class SeparatedListTests
{

    [TestMethod()]
    public void Normal1()
    {
        var list = new LinkedList<ASTNode>()
        {
            Node.New("a"), Node.New(","),
            Node.New("a")
        };
        var context = ParsingContext.New(list);
        var result = SeparatedList.New(ExpectString.New("a"), ExpectString.New(",")).Parsing(context);
        var expect = new LList<ASTNode>() {
            Node.New("a"),
            Node.New("a")
        };
        Assert.AreEqual(expect, result);
    }


    [TestMethod()]
    public void Normal2()
    {
        var list = new LinkedList<ASTNode>()
        {
            Node.New("a"), Node.New(","),
            Node.New("a"), Node.New(",")
        };
        var context = ParsingContext.New(list);
        var result = SeparatedList.New(ExpectString.New("a"), ExpectString.New(",")).Parsing(context);
        var expect = new LList<ASTNode>() {
            Node.New("a"),
            Node.New("a")
        };
        Assert.AreEqual(expect, result);
    }

    [TestMethod()]
    public void Empty1()
    {
        var list = new LinkedList<ASTNode>();
        var context = ParsingContext.New(list);
        var result = SeparatedList.New(ExpectString.New("a"), ExpectString.New(",")).Parsing(context);
        var expect = new LList<ASTNode>();
        Assert.AreEqual(expect, result);
    }

}