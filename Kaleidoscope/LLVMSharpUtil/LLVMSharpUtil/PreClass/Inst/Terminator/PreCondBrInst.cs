using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Terminator;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Terminator;

public class PreCondBrInst : PreInst
{

    public PreValue cond;
    public PreBasicBlock thenBasicBlock;
    public PreBasicBlock elseBasicBlock;

    public PreCondBrInst(PreValue cond, PreBasicBlock thenBasicBlock, PreBasicBlock elseBasicBlock) : base(new PreVoidTy())
    {
        this.cond = cond;
        this.thenBasicBlock = thenBasicBlock;
        this.elseBasicBlock = elseBasicBlock;
    }


    public override unsafe BuiltCondBrInst BuildValue(BuildContext context)
    {
        var builder = context.basicBlockBuilder!.llvmBuilder;

        var llvmValue = cond.Build(context).llvmValue;
        var llvmThenBasicBlock = thenBasicBlock.Build(context).llvmBasicBlock;
        var llvmElseBasicBlock = elseBasicBlock.Build(context).llvmBasicBlock;

        var llvmCondBrInst = LLVM.BuildCondBr(builder, llvmValue, llvmThenBasicBlock, llvmElseBasicBlock);
        var llvmReturnTy = type.Build(context).llvmType;
        return new(this, llvmCondBrInst, llvmReturnTy);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "CondBrInst {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "cond: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += cond.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "thenBasicBlock name: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += thenBasicBlock.name.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "elseBasicBlock name: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += elseBasicBlock.name.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
