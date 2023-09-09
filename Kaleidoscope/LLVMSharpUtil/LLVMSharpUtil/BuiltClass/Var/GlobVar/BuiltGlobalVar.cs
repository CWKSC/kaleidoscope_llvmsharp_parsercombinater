using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Var.GlobVar;

namespace LLVMSharpUtil_.BuiltClass.Var.GlobVar;

public class BuiltGlobalVar : BuiltVar
{

    public PreGlobalVar preGlobalVar;

    public unsafe BuiltGlobalVar(PreGlobalVar preGlobalVar, LLVMOpaqueValue* llvmValue, LLVMOpaqueType* llvmType) : base(preGlobalVar, llvmValue, llvmType)
    {
        this.preGlobalVar = preGlobalVar;
    }

}
