using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type.Int;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type.Int;

public class PreInt8Ty : PreIntTy
{

    public override unsafe BuiltInt8Ty BuildType(BuildContext context)
    {
        var llvmType = LLVM.Int8Type();
        return new(this, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Int8Ty { }".ToStr(printer);
        return result;
    }

}
