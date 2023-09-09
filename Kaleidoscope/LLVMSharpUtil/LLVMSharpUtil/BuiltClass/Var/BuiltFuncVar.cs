using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Var;

namespace LLVMSharpUtil_.BuiltClass.Var;

public class BuiltFuncVar : BuiltVar
{

    public PreFuncVar preFuncVar;

    public unsafe BuiltFuncVar(
        PreFuncVar preFuncVar,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preFuncVar, llvmValue, llvmType)
    {
        this.preFuncVar = preFuncVar;
    }

}
