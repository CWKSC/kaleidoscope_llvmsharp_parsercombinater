using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Func;
using LLVMSharpUtil_.BuiltClass.Var.GlobVar;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.Class.General;
using LLVMSharpUtil_.PreClass.Var.GlobVar;

namespace LLVMSharpUtil_.BuiltClass.General;

public class BuiltModule
{

    public PreModule preModule;

    public string name;
    public unsafe LLVMOpaqueModule* llvmModule;

    public List<BuiltGlobalVar> globalVarList = new();
    public Dictionary<PreGlobalVar, BuiltGlobalVar> globalVarDict = new();

    public List<BuiltFunc> funcList = new();
    public Dictionary<PreFunc, BuiltFunc> funcDict = new();

    public unsafe BuiltModule(PreModule preModule, string name, LLVMOpaqueModule* llvmModule)
    {
        this.preModule = preModule;
        this.name = name;
        this.llvmModule = llvmModule;
    }

    public void AddFunc(PreFunc preFunc, BuiltFunc builtFunc)
    {
        funcList.Add(builtFunc);
        funcDict[preFunc] = builtFunc;
    }

    public void AddGlobalVar(PreGlobalVar preGlobalVar, BuiltGlobalVar builtGlobalVar)
    {
        globalVarList.Add(builtGlobalVar);
        globalVarDict[preGlobalVar] = builtGlobalVar;
    }


    public unsafe void Run()
    {
        LLVM.LinkInMCJIT();
        LLVM.InitializeAllTargets();
        LLVM.InitializeX86TargetMC();

        LLVM.InitializeX86Target();
        LLVM.InitializeX86TargetInfo();
        LLVM.InitializeX86AsmParser();
        LLVM.InitializeX86AsmPrinter();

        LLVMSharpUtil.CreateExecutionEngineForModule(
            out var engine, out var _,
            llvmModule
        );
        var main = LLVM.GetNamedFunction(llvmModule, "main".ToSbytePointer());
        LLVM.RunFunction(engine, main, 0, null);
    }

    public unsafe void Print()
    {
        Console.WriteLine(new string(LLVM.PrintModuleToString(llvmModule)));
    }

    public override unsafe string ToString()
    {
        return new string(LLVM.PrintModuleToString(llvmModule));
    }

}
