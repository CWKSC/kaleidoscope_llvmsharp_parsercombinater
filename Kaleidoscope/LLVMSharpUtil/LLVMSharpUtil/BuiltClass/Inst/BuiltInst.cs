using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.Class.Inst;

namespace LLVMSharpUtil_.BuiltClass.Inst;

public class BuiltInst : BuiltValue
{

    public PreInst preInst;

    public unsafe BuiltInst(
        PreInst preInst,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preInst, llvmValue, llvmType)
    {
        this.preInst = preInst;
    }



}
