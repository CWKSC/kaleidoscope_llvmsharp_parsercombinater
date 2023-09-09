using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.BuiltClass.Func;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Inst.Memory;
using PrinterUtil;

namespace LLVMSharpUtil_.Class.Func;

public class PreFunc : PreValue
{

    public string name;
    public PreFuncTy funcTy;
    public List<PreBasicBlock> basicBlockList = new();
    public List<string> argNames;

    public Dictionary<string, PreAllocInst> nameToAllocInst = new();

    public PreFunc(
        string name,
        PreFuncTy funcTy,
        List<string> argNames
    ) : base(funcTy)
    {
        this.name = name;
        this.funcTy = funcTy;
        this.argNames = argNames;
    }

    public void AddBasicBlock(PreBasicBlock basicBlock)
    {
        basicBlockList.Add(basicBlock);
    }

    public override unsafe BuiltFunc BuildValue(BuildContext context)
    {
        var builtFuncTy = funcTy.BuildType(context);
        var llvmFuncTy = builtFuncTy.llvmType;
        var llvmFunc = LLVMSharpUtil.AddFunction(context.module, name, builtFuncTy);
        // LLVM.AddFunction(llvmModule, name.ToSbytePointer(), llvmFuncTy);

        var numberOfParams = funcTy.argTys.Count;
        var funcArgList = new List<BuiltValue>();
        var funcArgDict = new Dictionary<string, BuiltValue>();
        for (int i = 0; i < numberOfParams; i++)
        {
            var llvmValue = LLVM.GetParam(llvmFunc, (uint)i);
            var llvmType = funcTy.argTys[i].Build(context).llvmType;
            var bulitValue = new BuiltValue(this, llvmValue, llvmType);
            funcArgList.Add(bulitValue);
            funcArgDict[argNames[i]] = bulitValue;

        }

        return new(this, name, llvmFunc, llvmFuncTy, funcArgList, funcArgDict);
    }

    public unsafe void BuildBasicBlock(BuildContext context)
    {
        var func = context.func!;
        foreach (var block in basicBlockList)
        {
            var builtBasicBlock = block.Build(context);
            func.AppendExistingBasicBlock(block, builtBasicBlock);
        }
        foreach (var block in basicBlockList)
        {
            context.basicBlock = func.basicBlockDict[block];
            block.BuildInst(context);
            context.basicBlock = null;
        }
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Func {".ToStr(printer) + "\n";

        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += "insts: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var block in basicBlockList)
        {
            result += block.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
