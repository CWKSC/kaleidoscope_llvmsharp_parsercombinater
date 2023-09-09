using ListTreeUtil;
using PrinterUtil;

namespace CombinatorUtil;

public class Tagger
{

    readonly Dictionary<string, ASTNode> tagDict = new();

    public void Tag(ASTNode? node, string tag)
    {
        if (node == null) return;
        tagDict[tag] = node;
    }

    public void Tag2(LList<ASTNode> list, string tag1, string tag2) =>
        TagN(list, tag1, tag2);

    public void Tag3(LList<ASTNode> list, string tag1, string tag2, string tag3) =>
        TagN(list, tag1, tag2, tag3);

    public void TagN(LList<ASTNode> list, params string[] tags)
    {
        var length = tags.Length;
        if (list.Count() != length)
        {
            $"[Tag{length}] wrong number of destructure argument (expect {length} but actual )"
                .Print(new() { foregroundColor = ConsoleColor.Yellow });
        }

        for (int i = 0; i < length; i++)
        {
            var ele = list[i];
            tagDict[tags[i]] = ele;
        }

    }

    public ASTNode GetTag(string tag) => tagDict[tag];

    public T GetTag<T>(string tag)
    {
        var value = tagDict[tag];
        if (value is not T valueT) throw new Exception("[Tagger] GetTag type not match");
        return valueT;
    }


    readonly Dictionary<string, List<ASTNode>> tagRepeatDict = new();

    public void TagRepeat(ASTNode? node, string tag)
    {
        if (node == null) return;
        if (!tagRepeatDict.ContainsKey(tag))
        {
            tagRepeatDict[tag] = new();
        }
        tagRepeatDict[tag].Add(node);
    }

    public List<ASTNode> GetTagRepeat(string tag) => tagRepeatDict[tag];
    public List<T> GetTagRepeat<T>(string tag) where T : ASTNode
    {
        var list = tagRepeatDict[tag];
        return list.Cast<T>().ToList();
        //if (list is not List<T> listT) throw new Exception("[Tagger] GetTagRepeat type not match");
        //return listT;
    }

}
