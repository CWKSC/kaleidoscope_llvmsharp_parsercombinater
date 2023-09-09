using CombinatorUtil.GeneralCombinator_.Node_;
using CombinatorUtil.Recover;
using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil.Dervied;

public class OperatorAssociate : Combinator
{

    public List<(Combinator combinator, Associativity associativity)> operatorRules = new();
    public OperatorAssociate(List<(Combinator, Associativity)> operatorRules) => this.operatorRules = operatorRules;
    public static OperatorAssociate New(List<(Combinator, Associativity)> operatorRules) => new(operatorRules);
    public static OperatorAssociate New(params (Combinator, Associativity)[] operatorRules) => new(operatorRules.ToList());

    public override ASTNode? Parsing(ParsingContext context)
    {
        var bracketAST = GroupBracketRecursive(context.list);
        if (bracketAST == null) return null;
        ApplyAllOperatorRuleToBracket(context, bracketAST, operatorRules);

        var list = bracketAST.list;
        if (list.Count != 1)
        {
            $"[OperatorAssociate] Remain number of element not equal to 1, actual count: {list.Count}, there are some element havn't associate"
                .Print(new() { foregroundColor = ConsoleColor.Yellow });
            foreach (var item in list)
            {
                Console.WriteLine(item.ToStr(new()));
            }
            return null;
        }
        var first = bracketAST.list.First;
        if (first == null) return null;

        return first.Value;
    }


    public BracketAST? GroupBracketRecursive(LinkedList<ASTNode> list)
    {
        var first = list.First;
        if (first == null) return null;
        return GroupBracketRecursiveBody(list, ref first);
    }

    BracketAST GroupBracketRecursiveBody(LinkedList<ASTNode> list, ref LinkedListNode<ASTNode> current)
    {
        if (!list.Any()) return new();

        var bracketList = new LinkedList<ASTNode>();
        while (current != null && !current.Value.Equals(Node.New(")")))
        {
            var ele = current.Value;
            if (current.Value.Equals(Node.New("(")))
            {
                current = current.Next!;
                bracketList.AddLast(GroupBracketRecursiveBody(list, ref current));
            }
            else
            {
                bracketList.AddLast(ele);
            }
            current = current.Next!;
        }
        return new(bracketList);
    }

    public void ApplyAllOperatorRule(
        ParsingContext context,
        BracketAST bracketAST,
        List<(Combinator combinator, Associativity associativity)> operatorRules
    )
    {
        foreach (var rule in operatorRules)
        {
            ApplyOperatorRule(context, bracketAST, rule, operatorRules);
        }
    }

    public void ApplyAllOperatorRuleToBracket(
        ParsingContext context,
        BracketAST bracketAST,
        List<(Combinator combinator, Associativity associativity)> operatorRules
    )
    {
        foreach (var ele in bracketAST.list)
        {
            if (ele is BracketAST nestedBracket)
            {
                ApplyAllOperatorRuleToBracket(context, nestedBracket, operatorRules);
            }
        }

        ApplyAllOperatorRule(context, bracketAST, operatorRules);
    }

    public void ApplyOperatorRule(
        ParsingContext context,
        BracketAST bracketAST,
        (Combinator combinator, Associativity associativity) currentOperatorRules,
        List<(Combinator combinator, Associativity associativity)> operatorRules
    )
    {
        var combinator = currentOperatorRules.combinator;
        var associativity = currentOperatorRules.associativity;
        var list = bracketAST.list;
        var current = associativity == Associativity.Left ? list.First : list.Last;
        while (current != null)
        {
            var ele = current.Value;
            if (ele is BracketAST bracketInside)
            {
                ApplyAllOperatorRule(context, bracketInside, operatorRules);
            }
            else
            {
                var parsingContext = ParsingContext.New(context, list, current);
                var result = RecoverIfNull.New(combinator).Parsing(parsingContext);
                if (result != null)
                {
                    current = parsingContext.current;
                    if (current == null)
                    {
                        if (associativity == Associativity.Left)
                        {
                            parsingContext.list.AddLast(result);
                        }
                        else
                        {
                            parsingContext.list.AddFirst(result);
                        }
                    }
                    else
                    {
                        parsingContext.list.AddBefore(parsingContext.current!, result);
                        continue;
                    }
                }
                list = parsingContext.list;
                if (current == null) break;
                current = parsingContext.current;
                if (current == null) break;
            }
            current = associativity == Associativity.Left ? current.Next : current.Previous;
        }
        bracketAST.list = list;
    }

}

public enum Associativity
{
    Left, Right
}

