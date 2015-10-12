using System;
using System.Collections.Generic;
using UnityEngine;

public class IO_LoadBehavior : I_Observer_Behavior
{
    public void update(object arg)
    {
        if (arg is IO_Format == false) throw new System.ArgumentException("Invalid Type");
        
        IO_Format Format = (IO_Format)arg;

        String LoadedDataString = IO_Basic.Load(Format.gameObject.name);

        if (LoadedDataString == null) IO_Basic.Save(Format.gameObject.name, Format.GetData());
        else Format.setData(LoadedDataString);

    }
}

