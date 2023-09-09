using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.General;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Var.GlobVar;
using PrinterUtil;

namespace LLVMSharpUtil_.Class.General;

public class PreModule : IToStr
{

    public string name;

    public List<PreGlobalVar> globalVarList = new();
    public Dictionary<string, PreGlobalVar> globalVarDict = new();

    public List<PreFunc> funcList = new();
    public Dictionary<string, PreFunc> funcDict = new();

    public PreModule(string name = "") { this.name = name; }

    public unsafe BuiltModule Build(BuiltContext context)
    {
        var llvmContext = context.llvmContext;
        var module = LLVM.ModuleCreateWithNameInContext(name.ToSbytePointer(), llvmContext);

        var builtModule = new BuiltModule(this, name, module);
        var buildContext = new BuildContext(context, builtModule);


        foreach (var globalVar in globalVarList)
        {
            var builtGlobalVar = globalVar.BuildValue(buildContext);
            builtModule.AddGlobalVar(globalVar, builtGlobalVar);
        }

        foreach (var func in funcList)
        {
            var builtFunc = func.BuildValue(buildContext);
            builtModule.AddFunc(func, builtFunc);
        }
        foreach (var func in funcList)
        {
            buildContext.func = builtModule.funcDict[func];
            func.BuildBasicBlock(buildContext);
            buildContext.func = null;
        }

        return builtModule;
    }

    public void AddGlobalVar(PreGlobalVar globalVar)
    {
        globalVarList.Add(globalVar);
        globalVarDict[globalVar.name] = globalVar;
    }
    public PreGlobalVar GetGlobalVar(string name) => globalVarDict[name];


    public void AddFunc(PreFunc func)
    {
        funcList.Add(func);
        funcDict[func.name] = func;
    }

    public PreFunc GetFunc(string name) => funcDict[name];

    public bool IsContainFunc(string name) => funcDict.ContainsKey(name);

    public string ToStr(Printer printer)
    {
        var result = "";
        result += "Module {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        foreach (var globalVar in globalVarList)
        {
            result += globalVar.ToStr(printer) + "\n";
        }
        foreach (var func in funcList)
        {
            result += func.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
