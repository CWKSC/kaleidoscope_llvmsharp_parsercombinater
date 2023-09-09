using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type;

public class PreDoubleTy : PreType
{

    public override unsafe BuiltDoubleTy BuildType(BuildContext context)
    {
        var llvmType = LLVM.DoubleType();
        return new(this, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "DoubleTy { }".ToStr(printer);
        return result;
    }

}
