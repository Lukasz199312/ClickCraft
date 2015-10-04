using System;
using System.Collections.Generic;
using UnityEngine;

class IO_SaveBehavior: I_Observer_Behavior
{
    public void update(object arg)
    {
        if (arg is IO_Format == false) throw new System.ArgumentException("Invalid Type");

        IO_Format Format = (IO_Format)arg;
        IO_Basic.Save(Format.gameObject.name, Format.GetData());

    }
}
