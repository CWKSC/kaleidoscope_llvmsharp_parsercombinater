using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Builder;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Builder;

public class PreBasicBlockBuilder : PreBuilder
{

    public override unsafe BuiltBasicBlockBuilder Build(BuildContext context)
    {
        var llvmBuilder = LLVM.CreateBuilder();
        return new(this, llvmBuilder);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "BasicBlockBuilder { }".ToStr(printer);
        return result;
    }

}
