using LLVMSharp.Interop;
using LLVMSharpUtil_.PreClass.Builder;

namespace LLVMSharpUtil_.BuiltClass.Builder;

public class BuiltBasicBlockBuilder : BuiltBuilder
{

    public PreBasicBlockBuilder preBasicBlockBuilder;

    public unsafe BuiltBasicBlockBuilder(PreBasicBlockBuilder preBasicBlockBuilder, LLVMOpaqueBuilder* builder) : base(preBasicBlockBuilder, builder)
    {
        this.preBasicBlockBuilder = preBasicBlockBuilder;
    }


}


