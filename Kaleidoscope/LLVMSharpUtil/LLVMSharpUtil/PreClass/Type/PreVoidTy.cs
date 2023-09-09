using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type;

public class PreVoidTy : PreType
{

    public override unsafe BuiltVoidTy BuildType(BuildContext context)
    {
        var llvmType = LLVM.VoidType();
        return new(this, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "VoidTy { }".ToStr(printer);
        return result;
    }

}
