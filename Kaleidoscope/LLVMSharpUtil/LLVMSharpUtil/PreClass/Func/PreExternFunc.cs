using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.BuiltClass.Func;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Func;

public class PreExternFunc : PreFunc
{

    public new PreFuncTy funcTy;

    public unsafe PreExternFunc(
        string name,
        PreFuncTy funcTy,
        List<string> argNames
    ) : base(name, funcTy, argNames)
    {
        this.funcTy = funcTy;
    }

    public override unsafe BuiltExternFunc BuildValue(BuildContext context)
    {
        var llvmModule = context.module.llvmModule;
        var llvmFuncTy = type.Build(context).llvmType;
        var llvmFunc = LLVM.AddFunction(llvmModule, name.ToSbytePointer(), llvmFuncTy);
        LLVM.SetLinkage(llvmFunc, LLVMLinkage.LLVMExternalLinkage);

        var paramList = new List<BuiltValue>();
        var paramDict = new Dictionary<string, BuiltValue>();
        for (int i = 0; i < argNames.Count; i++)
        {
            var llvmValue = LLVM.GetParam(llvmFunc, (uint)i);
            var llvmType = funcTy.argTys[i].Build(context).llvmType;
            var bulitValue = new BuiltValue(this, llvmValue, llvmType);
            paramList.Add(bulitValue);
            paramDict[argNames[i]] = bulitValue;
        }

        return new BuiltExternFunc(this, name, llvmFunc, llvmFuncTy, paramList, paramDict);
    }


    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "ExternFunc {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += $"type: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += type.ToStr(printer) + "\n";
        printer.DecreaseIndent();
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
