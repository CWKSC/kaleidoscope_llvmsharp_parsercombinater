using CombinatorUtil.Node_;
using ListTreeUtil;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.PreClass.Inst.Arithmetic;
using PrinterUtil;

namespace Kaleidoscope.AST.Expr;

public class MultiplyExprAST : ExprAST
{

    public CodegenLLVMSharpEleNode LHS;
    public CodegenLLVMSharpEleNode RHS;

    public MultiplyExprAST(CodegenLLVMSharpEleNode LHS, CodegenLLVMSharpEleNode RHS)
    {
        this.LHS = LHS;
        this.RHS = RHS;
    }

    public override unsafe PreMulInst Codegen()
    {
        var lhsEle = LHS.Codegen();
        if (lhsEle is not PreValue lhsValue) throw new Exception("lhs is not PreValue");

        var rhsEle = RHS.Codegen();
        if (rhsEle is not PreValue rhsValue) throw new Exception("rhs is not PreValue");

        return new(lhsValue, rhsValue);
    }

    public override string ToStr(Printer printer)
    {
        var result = "";
        result += "MultiplyExpr {".ToStr(printer) + "\n";
        printer.IncreaseIndent();

        result += $"LHS: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        if (LHS is Node lhsNode)
        {
            result += lhsNode.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        result += $"RHS: ".ToStr(printer) + "\n";
        printer.IncreaseIndent();
        if (RHS is Node rhsNode)
        {
            result += rhsNode.ToStr(printer) + "\n";
        }
        printer.DecreaseIndent();

        printer.DecreaseIndent();
        result += "}".ToStr(printer);
        return result;
    }

}
