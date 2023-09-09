using LLVMSharpUtil_.BuiltClass.Type;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using PrinterUtil;

namespace LLVMSharpUtil_.PreClass.Type;

public class PreUnknownTy : PreType
{

    public override BuiltType BuildType(BuildContext context)
    {
        throw new NotImplementedException();
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "UnknownTy { }".ToStr(printer);
        return result;
    }

}
