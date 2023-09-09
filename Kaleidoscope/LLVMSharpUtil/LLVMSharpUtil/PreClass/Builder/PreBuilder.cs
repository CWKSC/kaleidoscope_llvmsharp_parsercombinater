using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Builder;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Base;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Builder;

public class PreBuilder : PreEle
{

    public override unsafe BuiltBuilder Build(BuildContext context)
    {
        var llvmBuilder = LLVM.CreateBuilder();
        return new(this, llvmBuilder);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Builder { }".ToStr(printer);
        return result;
    }

}
