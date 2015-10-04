using System;
using System.Collections.Generic;

public class SimpleDataPacker : DataPacker
{

    public override object Unpack(object ob)
    {
        if (ob is string == false) throw new System.ArgumentException("Invalid Type");

        object obj = new SimpleData();
        ((SimpleData)obj).Value = Convert.ToInt32((string)ob);
        return obj;
    }

    public override string Pack(object ob)
    {
        if (ob is SimpleData == false) throw new System.ArgumentException("Invalid Type");
        return ((SimpleData)ob).Value.ToString();
    }
}

