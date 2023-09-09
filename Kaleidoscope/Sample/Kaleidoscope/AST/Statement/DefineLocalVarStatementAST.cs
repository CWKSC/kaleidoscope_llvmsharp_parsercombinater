using Kaleidoscope.AST.Expr;
using LLVMSharpUtil_;
using LLVMSharpUtil_.Class.BasicBlock;
using LLVMSharpUtil_.Class.Func;
using LLVMSharpUtil_.PreClass.Inst.Memory;
using PrinterUtil;

namespace Kaleidoscope.AST.Statement;

public class DefineLocalVarStatementAST : StatementAST
{

    public string name;
    public string type;
    public ExprAST? initExpr = null;

    public DefineLocalVarStatementAST(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public DefineLocalVarStatementAST(string name, string type, ExprAST initExpr)
    {
        this.name = name;
        this.type = type;
        this.initExpr = initExpr;
    }

    public void Codegen(PreFunc func, PreBasicBlock basicBlock)
    {
        if (initExpr == null)
        {
            var preType = LLVMSharpUtil.GetPreType(type);
            var allocInst = new PreAllocInst(name, preType);
            basicBlock.AddInst(allocInst);

            func.nameToAllocInst[name] = allocInst;
        }
        else
        {
            var preType = LLVMSharpUtil.GetPreType(type);
            var allocInst = new PreAllocInst(name, preType);
            basicBlock.AddInst(allocInst);

            var preValue = initExpr.Codegen();
            var storeInst = new PreStoreInst(allocInst, preValue);
            basicBlock.AddInst(storeInst);

            func.nameToAllocInst[name] = allocInst;
        }
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "DefineLocalVarStatementAST {".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        result += $"name: {name}".ToStr(printer) + "\n";
        result += $"type: {type}".ToStr(printer) + "\n";
        if (initExpr != null)
        {
            result += $"initExpr: ".ToStr(printer) + "\n";
            printer.IncreaseIndent();
            result += initExpr.ToStr(printer) + "\n";
            printer.DecreaseIndent();
        }
        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
