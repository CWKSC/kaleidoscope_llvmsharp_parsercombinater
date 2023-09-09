using LLVMSharp.Interop;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{

    public static unsafe string ModuleToString(LLVMOpaqueModule* module)
    {
        return new string(LLVM.PrintModuleToString(module));
    }

    public static unsafe void PrintModule(LLVMOpaqueModule* module)
    {
        Console.WriteLine(ModuleToString(module));
    }

}