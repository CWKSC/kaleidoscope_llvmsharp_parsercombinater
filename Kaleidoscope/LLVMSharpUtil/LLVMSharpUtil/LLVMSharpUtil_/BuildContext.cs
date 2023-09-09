using LLVMSharpUtil_.BuiltClass.BasicBlock;
using LLVMSharpUtil_.BuiltClass.Builder;
using LLVMSharpUtil_.BuiltClass.Func;
using LLVMSharpUtil_.BuiltClass.General;

namespace LLVMSharpUtil_.LLVMSharpUtil_;

public class BuildContext
{

    public BuiltContext context;
    public BuiltModule module;

    public BuiltFunc? func = null;
    public BuiltBasicBlock? basicBlock = null;
    public BuiltBasicBlockBuilder? basicBlockBuilder = null;

    public BuildContext(BuiltContext context, BuiltModule module)
    {
        this.context = context;
        this.module = module;
    }



}
