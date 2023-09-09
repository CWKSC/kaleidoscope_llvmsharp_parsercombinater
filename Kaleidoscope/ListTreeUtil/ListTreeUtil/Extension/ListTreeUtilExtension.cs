namespace ListTreeUtil.Extension;

public static class ListTreeUtilExtension
{

    public static LinkedList<ASTNode> ToNodeOrList(this string value)
    {
        var nodeChars = value.Select(x => Node.New(x));
        return new LinkedList<ASTNode>(nodeChars);
    }

}
