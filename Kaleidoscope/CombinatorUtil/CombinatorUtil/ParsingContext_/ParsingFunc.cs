namespace CombinatorUtil.ParsingContext_;

public class ParsingFunc
{

    public string name;

    public ParsingFunc(string name)
    {
        this.name = name;
    }

    public Dictionary<string, string> funcArgsNameToType = new();

    public Dictionary<string, string> localVarNameToType = new();


}
