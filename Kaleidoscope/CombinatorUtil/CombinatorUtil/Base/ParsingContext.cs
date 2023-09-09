using CombinatorUtil.ParsingContext_;
using ListTreeUtil;

namespace CombinatorUtil;


public class ParsingContext
{

    public LinkedList<ASTNode> list;
    public LinkedListNode<ASTNode>? current;

    public ParsingFunc? parsingFunc = null;

    public ParsingContext(List<ASTNode> list)
    {
        this.list = new(list);
        current = this.list.First;
    }
    public ParsingContext(LinkedList<ASTNode> list)
    {
        this.list = list;
        current = list.First;
    }
    public ParsingContext(LinkedList<ASTNode> list, LinkedListNode<ASTNode>? current)
    {
        this.list = list;
        this.current = current;
    }

    public static ParsingContext New(List<ASTNode> list) => new(list);
    public static ParsingContext New(LinkedList<ASTNode> list) => new(list);
    public static ParsingContext New(LinkedList<ASTNode> list, LinkedListNode<ASTNode>? current) => new(list, current);


    public static ParsingContext New(ParsingContext old, List<ASTNode> list)
    {
        var newContext = old.Clone();
        newContext.list = new(list);
        newContext.current = newContext.list.First;
        return newContext;
    }
    public static ParsingContext New(ParsingContext old, LinkedList<ASTNode> list)
    {
        var newContext = old.Clone();
        newContext.list = list;
        newContext.current = newContext.list.First;
        return newContext;
    }
    public static ParsingContext New(ParsingContext old, LinkedList<ASTNode> list, LinkedListNode<ASTNode>? current)
    {
        var newContext = old.Clone();
        newContext.list = list;
        newContext.current = current;
        return newContext;
    }

    public ParsingContext Clone()
    {
        var position = 0;
        var findCurrentPosition = list.First;
        while (findCurrentPosition != null)
        {
            if (findCurrentPosition == current) break;
            position++;
            findCurrentPosition = findCurrentPosition.Next;
        }

        var copy = new LinkedList<ASTNode>(list);
        var copyCurrent = copy.First;
        for (int i = 0; i < position; i++)
        {
            copyCurrent = copyCurrent!.Next;
        }

        var newParsingContext = new ParsingContext(copy, copyCurrent);
        newParsingContext.parsingFunc = parsingFunc;
        // var copy_current = findCurrentPosition == null ? null : copy.Find(findCurrentPosition.Value);
        return newParsingContext;
    }

    public void ReplaceBy(ParsingContext context)
    {
        list = context.list;
        current = context.current;
    }

}

