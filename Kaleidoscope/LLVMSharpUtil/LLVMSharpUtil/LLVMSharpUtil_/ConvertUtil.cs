using LLVMSharp.Interop;
using LLVMSharpUtil_.Class.Base;
using LLVMSharpUtil_.Class.Type;
using LLVMSharpUtil_.LLVMSharpUtil_;
using System.Text;

namespace LLVMSharpUtil_;

public static partial class LLVMSharpUtil
{

    // string to sbyte* //
    public static unsafe sbyte* ToSbytePointer(this string value)
    {
        byte[] bytes = new byte[Encoding.Default.GetByteCount(value) + 1];
        Encoding.Default.GetBytes(value, 0, value.Length, bytes, 0);
        fixed (byte* b = bytes) { return (sbyte*)b; }
    }

    // string to sbyte* //
    public static unsafe string SbytePointerToString(sbyte* value)
    {
        return new string(value);
    }


    // LLVMOpaqueType*[] to LLVMOpaqueType** //
    public static unsafe LLVMOpaqueType** ToLLVMOpaqueTypePointerPointer(this LLVMOpaqueType*[] values)
    {
        fixed (LLVMOpaqueType** temp = values) { return temp; }
    }

    // LLVMOpaqueValue*[] to LLVMOpaqueValue** //
    public static unsafe LLVMOpaqueValue** ToLLVMOpaqueValuePointerPointer(this LLVMOpaqueValue*[] values)
    {
        fixed (LLVMOpaqueValue** temp = values) { return temp; }
    }


    // PreType[] to LLVMOpaqueType** //
    public static unsafe LLVMOpaqueType** ToLLVMOpaqueTypePointerPointer(this PreType[] typeList, BuildContext context)
    {
        var list = new LLVMOpaqueType*[typeList.Length];
        for (int i = 0; i < typeList.Length; i++)
        {
            list[i] = typeList[i].Build(context).llvmType;
        }
        return list.ToLLVMOpaqueTypePointerPointer();
    }

    // PreType[] to LLVMOpaqueType** //
    public static unsafe LLVMOpaqueValue** ToLLVMOpaqueTypePointerPointer(this List<PreValue> typeList, BuildContext context)
    {
        var list = new LLVMOpaqueValue*[typeList.Count];
        for (int i = 0; i < typeList.Count; i++)
        {
            list[i] = typeList[i].Build(context).llvmValue;
        }
        return list.ToLLVMOpaqueValuePointerPointer();
    }



}
