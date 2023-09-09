using LLVMSharp.Interop;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{


    public static readonly unsafe LLVMOpaqueValue* constInt0 = LLVM.ConstInt(LLVM.Int32Type(), 0, 1);



}
