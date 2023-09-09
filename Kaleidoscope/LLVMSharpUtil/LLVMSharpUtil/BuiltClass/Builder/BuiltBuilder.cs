using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.PreClass.Builder;

namespace LLVMSharpUtil_.BuiltClass.Builder;

public class BuiltBuilder : BuiltEle
{

    public PreBuilder preBuilder;
    public unsafe LLVMOpaqueBuilder* llvmBuilder;

    public unsafe BuiltBuilder(PreBuilder preBuilder, LLVMOpaqueBuilder* llvmBuilder) : base(preBuilder)
    {
        this.preBuilder = preBuilder;
        this.llvmBuilder = llvmBuilder;
    }

}
