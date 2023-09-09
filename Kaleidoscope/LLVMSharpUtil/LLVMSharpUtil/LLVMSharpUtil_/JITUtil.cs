using LLVMSharp.Interop;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{

    // Create ExecutionEngine for Module //
    public static unsafe void CreateExecutionEngineForModule(
        out LLVMOpaqueExecutionEngine* engine,
        out sbyte* error,
        LLVMOpaqueModule* module
    )
    {
        LLVMOpaqueExecutionEngine* outEE = null;
        sbyte* outError = null;
        _ = LLVM.CreateExecutionEngineForModule(&outEE, module, &outError);
        engine = outEE;
        error = outError;
    }

}