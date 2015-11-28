using System;
using System.Collections.Generic;
using UnityEngine;

class IO_SaveBehavior: I_Observer_Behavior
{
    public void update(object arg)
    {
        if (arg is I_Observer == false) throw new System.ArgumentException("Invalid Type");

        IO_Format Format =  ((I_Observer)arg).gameobject().GetComponent<IO_Format>();
        IO_Basic.Save(Format.gameObject.name, Format.GetData());

    }
}
