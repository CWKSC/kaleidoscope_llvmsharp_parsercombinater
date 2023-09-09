using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Var;

namespace LLVMSharpUtil_.BuiltClass.Var;

public class BuiltLocalVar : BuiltVar
{

    public PreLocalVar preLocalVar;

    public unsafe BuiltLocalVar(
        PreLocalVar preLocalVar,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preLocalVar, llvmValue, llvmType)
    {
        this.preLocalVar = preLocalVar;
    }

}
