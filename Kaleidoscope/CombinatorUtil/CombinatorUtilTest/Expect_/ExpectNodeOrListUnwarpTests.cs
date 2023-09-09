using CombinatorUtil.Expect_;
using ListTreeUtil;

namespace CombinatorUtilTest.Expect_;

[TestClass()]
public class ExpectNodeOrListUnwarpTests
{

    [TestMethod()]
    public void Normal1()
    {
        var combinator = ExpectNodeOrListUnwarp.New(Node.New(42));
        var result = TestTool.ApplyCombinator(combinator,
             Node.New(42), Node.New('c'), Node.New("string")
        );

        Assert.AreEqual(Node.New(42), result);
    }

    [TestMethod()]
    public void Fail1()
    {
        var combinator = ExpectNodeOrListUnwarp.New(Node.New(42));
        var result = TestTool.ApplyCombinator(combinator,
             Node.New(1000)
        );

        Assert.IsNull(result);
    }

    [TestMethod()]
    public void Fail2()
    {
        var combinator = ExpectNodeOrListUnwarp.New(Node.New(42));
        var result = TestTool.ApplyCombinator(combinator,
             Node.New('c')
        );

        Assert.IsNull(result);
    }

}