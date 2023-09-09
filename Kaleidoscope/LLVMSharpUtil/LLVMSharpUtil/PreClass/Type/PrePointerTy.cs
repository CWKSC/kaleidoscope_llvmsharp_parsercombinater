using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type;

public class PrePointerTy : PreType
{

    public PreType eleTy;
    public PrePointerTy(PreType eleTy) => this.eleTy = eleTy;

    public override unsafe BuiltPointerTy BuildType(BuildContext context)
    {
        var llvmEleTy = eleTy.Build(context).llvmType;
        var llvmType = LLVM.PointerType(llvmEleTy, 0);
        return new(this, llvmType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "PointerTy { }".ToStr(printer);
        return result;
    }

}
