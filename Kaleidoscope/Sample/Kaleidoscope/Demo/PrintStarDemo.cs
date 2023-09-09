using ListTreeUtil;
using ListTreeUtil.Extension;

namespace Kaleidoscope.Demo;

public class PrintStarDemo
{

    public static LinkedList<ASTNode> GetProgram() => @"
extern putchar(int32 x): int32

def mul2(int32 x): int32 {
    return 2 * x;
}

main {
    var i: int32 = 20;
    while i > 0 {
        var j: int32 = mul2(i);
        while j > 0 {
            call putchar(42);
            j = j - 1;
        }
        call putchar(10);
        i = i - 1;
    }
    return 0;
}
"
.ToNodeOrList();


}
