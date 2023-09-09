using LLVMSharpUtil_.BuiltClass.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Base;

namespace LLVMSharpUtil_.Class.Type;

public abstract class PreType : PreEle
{

    public abstract BuiltType BuildType(BuildContext context);

    public override BuiltType Build(BuildContext context) => BuildType(context);

}
