using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.Class.Type;

public class PreFuncTy : PreType
{

    public PreType returnTy;
    public List<PreType> argTys;
    public int isVarArgs;

    public unsafe PreFuncTy(
        PreType returnTy,
        List<PreType> argTys,
        int isVarArgs = 0
    )
    {
        this.returnTy = returnTy;
        this.argTys = argTys;
        this.isVarArgs = isVarArgs;
    }

    public override unsafe BuiltFuncTy BuildType(BuildContext context)
    {
        var llvmReturnTy = returnTy.Build(context).llvmType;
        var llvmParamTys = argTys.ToArray().ToLLVMOpaqueTypePointerPointer(context);
        var paramCount = (uint)argTys.Count;
        var funcTy = LLVM.FunctionType(llvmReturnTy, llvmParamTys, paramCount, isVarArgs);
        return new(this, funcTy);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "FuncTy {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += "returnTy: ".ToStr(printer) + "\n";

        printer.IncreaseIndent();
        result += returnTy.ToStr(printer) + "\n";
        printer.DecreaseIndent();

        result += "paramTys: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var param in argTys)
        {
            result += param.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
