using LLVMSharpUtil_.BuiltClass.Base;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Base;

public abstract class PreEle : IToStr
{
    public abstract BuiltEle Build(BuildContext context);

    public abstract string ToStr(Printer printer);

}
