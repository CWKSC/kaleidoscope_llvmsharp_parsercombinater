using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Inst.Other;

namespace LLVMSharpUtil_.BuiltClass.Inst.Other;

public class BuiltFuncCall : BuiltInst
{

    public PreFuncCallInst preFuncCall;

    public unsafe BuiltFuncCall(
        PreFuncCallInst preFuncCall,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preFuncCall, llvmValue, llvmType)
    {
        this.preFuncCall = preFuncCall;
    }

}
