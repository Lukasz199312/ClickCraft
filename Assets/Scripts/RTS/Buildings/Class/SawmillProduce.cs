using UnityEngine;
using System.Collections;
using System;

public class SawmillProduce : I_Produce
{
    private Lumberjack Lumber;
    private DisplayTimer Timer;

    public SawmillProduce()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) Lumber = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void StartProduce(Building building)
    {
        
    }

    public void setTimer(DisplayTimer Timer)
    {
        this.Timer = Timer;
    }

    public DisplayTimer getTimer()
    {
        return Timer;
    }

 
}
