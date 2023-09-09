using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.BasicBlock;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Base;
using PrinterUtil;

namespace LLVMSharpUtil_.Class.BasicBlock;

public class PreBasicBlock : PreEle
{

    public string name;
    public List<PreInst> instList = new();

    public bool isBuilt = false;
    public BuiltBasicBlock? builtBasicBlock = null;

    public unsafe PreBasicBlock(string name) => this.name = name;

    public void AddInst(PreInst inst) => instList.Add(inst);

    public override unsafe BuiltBasicBlock Build(BuildContext buildContext)
    {
        if (isBuilt) return builtBasicBlock!;
        var context = buildContext.context.llvmContext;
        var basicBlock = LLVM.CreateBasicBlockInContext(context, name.ToSbytePointer());
        builtBasicBlock = new(this, name, basicBlock);
        isBuilt = true;
        return builtBasicBlock;
    }

    public void BuildInst(BuildContext buildContext)
    {
        var basicBlock = buildContext.basicBlock!;
        buildContext.basicBlockBuilder = basicBlock.GetBuilder();
        foreach (var inst in instList)
        {
            inst.Build(buildContext);
        }
        buildContext.basicBlockBuilder = null;
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "BasicBlock {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += "inst:".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var inst in instList)
        {
            result += inst.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
