using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Inst.Other;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.Inst;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Type;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Inst.Other;

public class PreFuncCallInst : PreInst
{

    public PreFunc func;
    public List<PreValue> parameters;

    public PreFuncCallInst(PreFunc func, List<PreValue> parameters) : base(func.funcTy.returnTy)
    {
        this.func = func;
        this.parameters = parameters;
    }

    public override unsafe BuiltFuncCall BuildValue(BuildContext context)
    {
        var llvmFunc = context.module.funcDict[func].llvmValue;
        var llvmFuncTy = func.type.Build(context).llvmType;
        var llvmReturnType = func.funcTy.returnTy.Build(context).llvmType;
        var llvmBuilder = context.basicBlockBuilder!.llvmBuilder;

        var tempVarName = (func.funcTy.returnTy is PreVoidTy ? "" : "call_temp").ToSbytePointer();
        var llvmCallInst = LLVM.BuildCall2(
            llvmBuilder,
            llvmFuncTy,
            llvmFunc,
            parameters.ToLLVMOpaqueTypePointerPointer(context),
            (uint)parameters.Count,
            tempVarName
        );

        return new(this, llvmCallInst, llvmReturnType);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "FuncCall {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += "name: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += func.name.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "parameters: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var param in parameters)
        {
            result += param.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
