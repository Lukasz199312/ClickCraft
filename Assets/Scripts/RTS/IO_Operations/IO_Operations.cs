using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IO_Operations : Subject{
	
    void OnApplicationQuit()
    {
        AdviseAll(new IO_SaveBehavior());
        IO_Basic.SaveAll();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        AdviseAll(new IO_SaveBehavior());
        IO_Basic.SaveAll();
    }



}
