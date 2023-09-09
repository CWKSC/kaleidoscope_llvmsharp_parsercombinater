using ListTreeUtil;
using LLVMSharpUtil_;
using LLVMSharpUtil_.Class.Type;
using PrinterUtil;

namespace Kaleidoscope.AST;

public class PrototypeAST : Node
{
    public string name;
    public List<string> argNames = new();
    public List<string> argTys = new();
    public Dictionary<string, string> argNameToType = new();
    public string returnType;
    public int isVarArgs;

    public PrototypeAST(string name, List<string> argNames, List<string> argTys, string returnType, int isVarArgs)
    {
        this.name = name;
        this.argNames = argNames;
        this.argTys = argTys;
        this.returnType = returnType;
        this.isVarArgs = isVarArgs;

        for (int i = 0; i < argNames.Count; i++)
        {
            argNameToType[argNames[i]] = argTys[i];
        }
    }

    public unsafe PreFuncTy Codegen()
    {
        var returnTy = LLVMSharpUtil.GetPreType(returnType);
        var paramTys = argTys.Select(LLVMSharpUtil.GetPreType).ToList();
        return new PreFuncTy(returnTy, paramTys, isVarArgs);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "Prototype {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += $"args: {string.Join(", ", argNames)}".ToStr(printer) + "\n";
        result += $"argTys: {string.Join(", ", argTys)}".ToStr(printer) + "\n";
        result += $"isVarArgs: {isVarArgs}".ToStr(printer) + "\n";
        result += $"return: {returnType}".ToStr(printer) + "\n";
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
