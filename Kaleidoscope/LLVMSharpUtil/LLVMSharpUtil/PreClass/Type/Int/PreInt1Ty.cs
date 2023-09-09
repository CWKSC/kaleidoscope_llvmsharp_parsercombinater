using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type.Int;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type.Int;

public class PreInt1Ty : PreIntTy
{

    public override unsafe BuiltInt1Ty BuildType(BuildContext context)
    {
        var llvmType = LLVM.Int1Type();
        return new(this, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Int1Ty { }".ToStr(printer);
        return result;
    }

}
