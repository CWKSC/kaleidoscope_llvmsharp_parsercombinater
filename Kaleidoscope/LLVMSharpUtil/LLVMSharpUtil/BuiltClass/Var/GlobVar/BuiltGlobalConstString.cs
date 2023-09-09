using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Var.GlobVar;

namespace LLVMSharpUtil_.BuiltClass.Var.GlobVar;

public class BuiltGlobalConstString : BuiltGlobalVar
{

    public PreGlobalConstString preConstString;

    public unsafe BuiltGlobalConstString(
        PreGlobalConstString preConstString,
        LLVMOpaqueValue* llvmValue,
        LLVMOpaqueType* llvmType
    ) : base(preConstString, llvmValue, llvmType)
    {
        this.preConstString = preConstString;
    }

}
