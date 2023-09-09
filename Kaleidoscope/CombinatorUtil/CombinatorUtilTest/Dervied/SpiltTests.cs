using CombinatorUtil;
using CombinatorUtil.Dervied;
using CombinatorUtil.Parser.Expect_;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.Dervied;

[TestClass()]
public class SpiltTests
{

    [TestMethod()]
    public void Normal1()
    {
        var list = new LinkedList<ASTNode>()
        {
            Node.New("int"), Node.New("a"), Node.New(","),
            Node.New("char"), Node.New("b"), Node.New(","),
            Node.New("string"), Node.New("c")
        };
        var context = ParsingContext.New(list);
        var result = Spilt.New(ExpectString.New(",")).Parsing(context);
        var expect = new LList<LList<ASTNode>>() {
            new LList<ASTNode>()
            {
                Node.New("int"), Node.New("a")
            },
            new LList<ASTNode>()
            {
                Node.New("char"), Node.New("b")
            },
            new LList<ASTNode>()
            {
                Node.New("string"), Node.New("c")
            }
        };
        Assert.AreEqual(expect, result);
    }

}