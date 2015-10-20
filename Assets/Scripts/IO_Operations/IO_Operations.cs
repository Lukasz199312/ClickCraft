using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IO_Operations : Subject{
	
    void OnApplicationQuit()
    {
        IEnumerator<I_Observer> iter = Observers.GetEnumerator();

        while (iter.MoveNext())
        {
            I_Observer ob = iter.Current;
            IO_Format format = ob.gameobject().GetComponent<IO_Format>();

            ob.ChangeBehavior(this, new IO_SaveBehavior()).update(format);
            IO_Basic.SaveAll();
        }
    }



}
