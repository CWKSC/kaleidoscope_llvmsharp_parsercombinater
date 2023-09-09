using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Terminator;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Terminator;

public class PreBrInst : PreInst
{

    public PreBasicBlock destBasicBlock;

    public PreBrInst(PreBasicBlock destBasicBlock) : base(new PreVoidTy())
    {
        this.destBasicBlock = destBasicBlock;
    }

    public override unsafe BuiltBrInst BuildValue(BuildContext context)
    {
        var builder = context.basicBlockBuilder!.llvmBuilder;

        var llvmDestBasicBlock = destBasicBlock.Build(context).llvmBasicBlock;

        var llvmBrInst = LLVM.BuildBr(builder, llvmDestBasicBlock);
        var llvmReturnTy = type.Build(context).llvmType;
        return new(this, llvmBrInst, llvmReturnTy);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "BrInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "destBasicBlock name: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += destBasicBlock.name.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
