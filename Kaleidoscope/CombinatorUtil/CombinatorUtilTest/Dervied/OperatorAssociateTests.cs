using CombinatorUtil.Dervied;
using CombinatorUtil.GeneralCombinator_.Grouping;
using CombinatorUtil.GeneralCombinator_.Grouping.BinraryOperator_;
using CombinatorUtil.GeneralCombinator_.Node_;
using ListTreeUtil;

namespace CombinatorUtilTest.Dervied;

[TestClass()]
public class OperatorAssociateTests
{

    [TestMethod()]
    public void Normal1()
    {
        var operatorAssociate = OperatorAssociate.New(
            (GroupBinraryOperator.New("*"), Associativity.Left),
            (GroupBinraryOperator.New("+"), Associativity.Left)
        );

        var result = TestTool.ApplyCombinator(operatorAssociate,
            Node.New("1"), Node.New("+"), Node.New("2"), Node.New("*"), Node.New("3")
        );
        if (result == null) Assert.Fail();
        Console.WriteLine(result.ToStr(new()));

        var expect = new BinraryOperatorAST(
            "+",
            Node.New("1"),
            new BinraryOperatorAST(
                "*",
                Node.New("2"),
                Node.New("3")
            )
        );
        Assert.AreEqual(expect, result);
    }


    [TestMethod()]
    public void Normal2()
    {
        var operatorAssociate = OperatorAssociate.New(
            (GroupBinraryOperator.New("*"), Associativity.Left),
            (GroupBinraryOperator.New("/"), Associativity.Left),
            (GroupBinraryOperator.New("+"), Associativity.Left),
            (GroupBinraryOperator.New("-"), Associativity.Left)
        );

        var result = TestTool.ApplyCombinator(operatorAssociate,
            Node.New("1"), Node.New("+"), Node.New("2"), Node.New("*"), Node.New("3"), Node.New("-"), Node.New("4"), Node.New("/"), Node.New("5")
        );
        if (result == null) Assert.Fail();
        Console.WriteLine(result.ToStr(new()));

        var expect = new BinraryOperatorAST(
            "-",
            new BinraryOperatorAST(
                "+",
                Node.New("1"),
                new BinraryOperatorAST(
                    "*",
                    Node.New("2"),
                    Node.New("3")
                )
            ),
            new BinraryOperatorAST(
                "/",
                Node.New("4"),
                Node.New("5")
            )
        );
        Assert.AreEqual(expect, result);
    }



    [TestMethod()]
    public void Normal3()
    {
        var operatorAssociate = OperatorAssociate.New(
            (GroupBinraryOperator.New("*"), Associativity.Left),
            (GroupBinraryOperator.New("/"), Associativity.Left),
            (GroupBinraryOperator.New("+"), Associativity.Left),
            (GroupBinraryOperator.New("-"), Associativity.Left)
        );

        var result = TestTool.ApplyCombinator(operatorAssociate,
            Node.New("1"), Node.New("+"), Node.New("2"), Node.New("*"), Node.New("("), Node.New("3"), Node.New("-"), Node.New("4"), Node.New(")")
        );
        if (result == null) Assert.Fail();
        Console.WriteLine(result.ToStr(new()));

        var expect = new BinraryOperatorAST(
            "+",
            Node.New("1"),
            new BinraryOperatorAST(
                "*",
                Node.New("2"),
                new BracketAST(
                    new BinraryOperatorAST(
                        "-",
                        Node.New("3"),
                        Node.New("4")
                    )
                )
            )
        );
        Console.WriteLine(expect.ToStr(new()));
        Assert.AreEqual(expect, result);
    }




    [TestMethod()]
    public void Normal4()
    {
        var operatorAssociate = OperatorAssociate.New(
            (GroupBinraryOperator.New("*"), Associativity.Left),
            (GroupBinraryOperator.New("/"), Associativity.Left),
            (GroupBinraryOperator.New("+"), Associativity.Left),
            (GroupBinraryOperator.New("-"), Associativity.Left)
        );

        // (1 * 2) * (3 * (4 + 5)) - (6 / 7)
        var result = TestTool.ApplyCombinator(operatorAssociate,
            Node.New("("), Node.New("1"), Node.New("*"), Node.New("2"), Node.New(")"),
            Node.New("*"),
            Node.New("("), Node.New("3"), Node.New("*"),
                Node.New("("), Node.New("4"), Node.New("+"), Node.New("5"), Node.New(")"),
            Node.New(")"),
            Node.New("-"),
            Node.New("("), Node.New("6"), Node.New("/"), Node.New("7"), Node.New(")")
        );
        if (result == null) Assert.Fail();
        Console.WriteLine(result.ToStr(new()));

        var expect = new BinraryOperatorAST(
            "-",
            new BinraryOperatorAST(
                "*",
                new BracketAST(
                    new BinraryOperatorAST(
                        "*",
                        Node.New("1"),
                        Node.New("2")
                    )
                ),
                new BracketAST(
                    new BinraryOperatorAST(
                        "*",
                        Node.New("3"),
                        new BracketAST(
                            new BinraryOperatorAST(
                                "+",
                                Node.New("4"),
                                Node.New("5")
                            )
                        )
                    )
                )
            ),
            new BracketAST(
                new BinraryOperatorAST(
                    "/",
                    Node.New("6"),
                    Node.New("7")
                )
            )
        );
        Assert.AreEqual(expect, result);
    }



    [TestMethod()]
    public void Normal5_FunctionCallee()
    {
        var operatorAssociate = OperatorAssociate.New(
            (GroupFunctionCallee.New(), Associativity.Left),
            (GroupBinraryOperator.New("*"), Associativity.Left),
            (GroupBinraryOperator.New("/"), Associativity.Left),
            (GroupBinraryOperator.New("+"), Associativity.Left),
            (GroupBinraryOperator.New("-"), Associativity.Left)
        );

        // (1 * 2) * (3 * (4 + 5)) - (6 / 7)
        var result = TestTool.ApplyCombinator(operatorAssociate,
            Node.New("foo"), Node.New("("), Node.New("a"), Node.New("b"), Node.New("c"), Node.New(")"),
            Node.New("*"),
            Node.New("boo"), Node.New("("), Node.New(")")
        );
        if (result == null) Assert.Fail();
        Console.WriteLine(result.ToStr(new()));

        var expect = new BinraryOperatorAST(
            "*",
            new FunctionCalleeAST(
                "foo",
                new() { "a", "b", "c" }
            ),
            new FunctionCalleeAST(
                "boo",
                new() { }
            )
        );
        Assert.AreEqual(expect, result);
    }



    [TestMethod()]
    public void Normal6()
    {
        var operatorAssociate = OperatorAssociate.New(
            (GroupFunctionCallee.New(), Associativity.Left),
            (GroupBinraryOperator.New("*"), Associativity.Left),
            (GroupBinraryOperator.New("/"), Associativity.Left),
            (GroupBinraryOperator.New("+"), Associativity.Left),
            (GroupBinraryOperator.New("-"), Associativity.Left)
        );

        // a*a + 2*a*b + b*b
        var result = TestTool.ApplyCombinator(operatorAssociate,
            Node.New("a"), Node.New("*"), Node.New("a"), Node.New("+"),
            Node.New("2"), Node.New("*"), Node.New("a"), Node.New("*"), Node.New("b"), Node.New("+"),
            Node.New("b"), Node.New("*"), Node.New("b")
        );
        if (result == null) Assert.Fail();
        Console.WriteLine(result.ToStr(new()));

        var expect = new BinraryOperatorAST(
            "+",
            new BinraryOperatorAST(
                "+",
                new BinraryOperatorAST(
                    "*",
                    Node.New("a"),
                    Node.New("a")
                ),
                new BinraryOperatorAST(
                    "*",
                    new BinraryOperatorAST(
                        "*",
                        Node.New("2"),
                        Node.New("a")
                    ),
                    Node.New("b")
                )
            ),
            new BinraryOperatorAST(
                "*",
                Node.New("b"),
                Node.New("b")
            )
        );
        Assert.AreEqual(expect, result);
    }



}