using CombinatorUtil.Node_;
using ListTreeUtil;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.PreClass.Inst.Other;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr;

public class FuncCalleeAST : ExprAST
{

    public string name;
    public List<CodegenLLVMSharpEleNode> args = new();

    public FuncCalleeAST(string name, List<CodegenLLVMSharpEleNode> args)
    {
        this.name = name;
        this.args = args;
    }

    public override unsafe PreFuncCallInst Codegen()
    {
        var exist = Resource.module.IsContainFunc(name);
        if (!exist) throw new Exception("function not exist");

        var func = Resource.module.GetFunc(name);

        var paramList = new List<PreValue>();
        foreach (var ele in args)
        {
            var llvmSharpEle = ele.Codegen();
            if (llvmSharpEle is PreValue value)
            {
                paramList.Add(value);
            }
        }
        return new PreFuncCallInst(func, paramList);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "FunctionCallee {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += $"args: ".ToStr(printer) + "\n";

        printer.IncreaseIndent();
        foreach (var arg in args)
        {
            if (arg is Node node)
            {
                result += node.ToStr(printer) + "\n";
            }
        }
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
