using LLVMSharp.Interop;
using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.BuiltClass.Builder;
using LLVMSharpUtil_.Class.BasicBlock;

namespace LLVMSharpUtil_.BuiltClass.BasicBlock;

public class BuiltBasicBlock : BuiltEle
{

    public PreBasicBlock preBasicBlock;
    public string name;
    public unsafe LLVMOpaqueBasicBlock* llvmBasicBlock;

    public unsafe BuiltBasicBlock(PreBasicBlock preBasicBlock, string name, LLVMOpaqueBasicBlock* llvmBasicBlock) : base(preBasicBlock)
    {
        this.preBasicBlock = preBasicBlock;
        this.name = name;
        this.llvmBasicBlock = llvmBasicBlock;
    }


    public unsafe BuiltBasicBlockBuilder GetBuilder()
    {
        var llvmBuilder = LLVM.CreateBuilder();
        LLVM.PositionBuilderAtEnd(llvmBuilder, llvmBasicBlock);
        return new(new(), llvmBuilder);
    }


}
