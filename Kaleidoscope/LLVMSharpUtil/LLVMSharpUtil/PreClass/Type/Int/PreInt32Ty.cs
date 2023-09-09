using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type.Int;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type.Int;

public class PreInt32Ty : PreIntTy
{

    public override unsafe BuiltInt32Ty BuildType(BuildContext context)
    {
        var llvmType = LLVM.Int32Type();
        return new(this, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Int32Ty { }".ToStr(printer);
        return result;
    }

}
