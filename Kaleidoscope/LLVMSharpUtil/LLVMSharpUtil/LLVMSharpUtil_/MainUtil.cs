using LLVMSharp.Interop;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{


    //// Create main function //
    //public static unsafe void CreateMain(
    //    out LLVMOpaqueValue* mainFunc,
    //     out LLVMOpaqueType* mainFuncTy,
    //    out LLVMOpaqueBuilder* mainBuilder,

    //    LLVMOpaqueModule* module
    //)
    //{
    //    CreateFunction(
    //        out mainFunc, out mainFuncTy, out mainBuilder,
    //        module, "main", LLVM.Int32Type(), new LLVMOpaqueType*[] { }
    //    );
    //}


    // Run module in JIT Compiler //
    // Sometimes crashes with "LLVM ERROR: IMAGE_REL_AMD64_ADDR32NB relocation requires an ordered section layout"
    public static unsafe void RunMain(LLVMOpaqueModule* module)
    {
        LLVM.LinkInMCJIT();
        LLVM.InitializeX86TargetMC();

        LLVM.InitializeX86Target();
        LLVM.InitializeX86TargetInfo();
        LLVM.InitializeX86AsmParser();
        LLVM.InitializeX86AsmPrinter();

        CreateExecutionEngineForModule(
            out var engine, out var _,
            module
        );
        var main = LLVM.GetNamedFunction(module, "main".ToSbytePointer());
        LLVM.RunFunction(engine, main, 0, null);
    }


}
