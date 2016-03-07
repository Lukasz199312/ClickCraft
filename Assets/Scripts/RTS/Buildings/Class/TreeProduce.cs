using UnityEngine;
using System.Collections;
using System;

public class TreeProduce : I_Produce
{
    private Lumberjack Lumber;
    private DisplayTimer Timer;

    public TreeProduce()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) Lumber = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void StartProduce(Building building)
    {
        if (building.Build_Statistic.Capacity >= Lumber._AutoStatistic.MaxCapacity)
        {

        }
        else
        {
           float result =  (((GlobalTimer)building.subject).RefreshTime / Lumber._AutoStatistic.Speed) * Lumber._AutoStatistic.HitPoints;
           building.Build_Statistic.Capacity += result;
            ((Tree)building).Capacity.add((int)result);
        }


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
