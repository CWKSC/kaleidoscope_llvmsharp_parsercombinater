using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.PreClass.Var;

namespace LLVMSharpUtil_.BuiltClass.Var;

public class BuiltVar : BuiltValue
{

    public PreVar preVar;

    public unsafe BuiltVar(
        PreVar preVar,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preVar, llvmValue, llvmType)
    {
        this.preVar = preVar;
    }

}
