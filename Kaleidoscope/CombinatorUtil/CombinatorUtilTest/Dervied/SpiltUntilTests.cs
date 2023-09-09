using CombinatorUtil;
using CombinatorUtil.Dervied;
using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Dervied;

[TestClass]
public class SpiltUntilTests
{

    [TestMethod]
    public void Normal1()
    {
        var list = new LinkedList<ASTNode>()
        {
            Node.New("1"), Node.New("+"), Node.New("2"), Node.New(";")
        };
        var context = ParsingContext.New(list);
        var result = SpiltUntil.New(ExpectString.New(";")).Parsing(context);
        var expect = new LList<ASTNode>() { Node.New("1"), Node.New("+"), Node.New("2") };
        CollectionAssert.AreEqual(expect.ToList(), result.ToList());
    }

    [TestMethod]
    public void Empty1()
    {
        var list = new LinkedList<ASTNode>()
        {
           Node.New(";")
        };
        var context = ParsingContext.New(list);
        var result = SpiltUntil.New(ExpectString.New(";")).Parsing(context);
        var expect = new LList<ASTNode>();
        CollectionAssert.AreEqual(expect.ToList(), result.ToList());
    }


    [TestMethod]
    public void Fail1()
    {
        var list = new LinkedList<ASTNode>()
        {
            Node.New("42"), Node.New(";")
        };
        var context = ParsingContext.New(list);
        var result = SpiltUntil.New(ExpectString.New(";")).Parsing(context);
        var expect = new LList<Node<string>>() { Node.New("43") };
        CollectionAssert.AreNotEqual(expect.ToList(), result.ToList());
    }


}