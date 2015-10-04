using System;
using System.Collections.Generic;

public class StringDataPacker : DataPacker
{

    public override object Unpack(object ob)
    {
        if (ob is string == false) throw new System.ArgumentException("Invalid Type");

        object obj = new StringData();
        ((StringData)obj).Value = (string)ob;
        return obj;
    }

    public override string Pack(object ob)
    {
        if (ob is StringData == false) throw new System.ArgumentException("Invalid Type");
        return ((StringData)ob).Value.ToString();
    }
}

