using LLVMSharpUtil_.BuiltClass.Var.GlobVar;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;

namespace LLVMSharpUtil_.PreClass.Var.GlobVar;

public abstract class PreGlobalVar : PreVar
{

    public PreGlobalVar(string name, PreType type) : base(name, type)
    {

    }

    public override BuiltGlobalVar BuildValue(BuildContext context) => BuildGlobalVar(context);

    public abstract BuiltGlobalVar BuildGlobalVar(BuildContext context);

}
