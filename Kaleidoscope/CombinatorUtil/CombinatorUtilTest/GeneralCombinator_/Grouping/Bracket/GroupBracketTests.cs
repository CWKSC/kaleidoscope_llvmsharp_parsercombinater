using CombinatorUtil.GeneralCombinator_.Grouping.Bracket;
using CombinatorUtil.GeneralCombinator_.Node_;
using ListTreeUtil;
using Util;

namespace CombinatorUtilTest.GeneralCombinator_.Grouping.Bracket;

[TestClass()]
public class GroupBracketTests
{

    [TestMethod()]
    public void Normal1()
    {
        var groupBracket = GroupBracket.New();
        var (context, result) = TestTool.ApplyCombinatorWithContext(groupBracket,
            Node.New("("), Node.New("a"), Node.New("b"), Node.New(")")
        );

        var expect = new BracketAST(new LinkedList<ASTNode>() { Node.New("a"), Node.New("b") });
        Assert.AreEqual(expect, result);
        Assert.AreEqual(0, context.list.Count);
    }


    [TestMethod()]
    public void Normal2()
    {
        var groupBracket = GroupBracket.New();
        var (context, result) = TestTool.ApplyCombinatorWithContext(groupBracket,
            Node.New("("),
                Node.New("a"),
                Node.New("("),
                    Node.New("b"),
                Node.New(")"),
                Node.New("c"),
            Node.New(")")
        );

        var expect = new BracketAST(new LinkedList<ASTNode>() {
            Node.New("a"),
            new BracketAST(new LinkedList<ASTNode>() {
                Node.New("b")
            }),
            Node.New("c")
        });
        Assert.AreEqual(expect, result);
        Assert.AreEqual(0, context.list.Count);
    }

    [TestMethod()]
    public void Normal3()
    {
        var groupBracket = GroupBracket.New();
        var (context, result) = TestTool.ApplyCombinatorWithContext(groupBracket,
            Node.New("("),
                Node.New("("),
                    Node.New("("),
                    Node.New(")"),
                Node.New(")"),
                Node.New("("),
                Node.New(")"),
            Node.New(")")
        );

        var expect = new BracketAST(new LinkedList<ASTNode>() {
            new BracketAST(new LinkedList<ASTNode>() {
                new BracketAST(new LinkedList<ASTNode>() {

                })
            }),
            new BracketAST(new LinkedList<ASTNode>() {

            })
        });
        Assert.AreEqual(expect, result);
        Assert.AreEqual(0, context.list.Count);
    }



    [TestMethod()]
    public void Fail1()
    {
        var groupBracket = GroupBracket.New();
        var (context, result) = TestTool.ApplyCombinatorWithContext(groupBracket,
            Node.New("("), Node.New("a"), Node.New("b"), Node.New(")")
        );

        var noEqual = new BracketAST(new LinkedList<ASTNode>() { Node.New("c"), Node.New("d") });
        Assert.AreNotEqual(noEqual, result);
        Assert.AreEqual(0, context.list.Count);
    }

    [TestMethod()]
    public void Fail2()
    {
        var groupBracket = GroupBracket.New();
        var result = TestTool.ApplyCombinator(groupBracket,
            Node.New("a"), Node.New("b"), Node.New("c")
        );

        Assert.IsNull(result);
    }

}
