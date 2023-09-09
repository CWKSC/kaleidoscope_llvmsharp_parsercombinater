using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using LLVMSharpUtil_.PreClass.Base;

namespace LLVMSharpUtil_.Class.Base;

public abstract class PreValue : PreEle
{

    public PreType type;
    public PreValue(PreType type) => this.type = type;

    public abstract BuiltValue BuildValue(BuildContext context);
    public override BuiltValue Build(BuildContext context) => BuildValue(context);



}
