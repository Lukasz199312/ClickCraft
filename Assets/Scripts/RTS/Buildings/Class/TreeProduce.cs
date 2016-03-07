using UnityEngine;
using System.Collections;
using System;

public class TreeProduce : I_Produce
{
    private Lumberjack builder;
    private DisplayTimer Timer;

    public TreeProduce()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) builder = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void StartProduce(Building building)
    {
        building.Build_Statistic.ProgressProduction += (((GlobalTimer)building.subject).RefreshTime / building.Build_Statistic.Speed) * building.Build_Statistic.UP_HitPoints;

        if (building.Build_Statistic.ProgressProduction >= building.ResourceProduction.RequiredHitPoints)
        {
            building.Build_Statistic.ResetProgressProduction(building.ResourceProduction);
            building.ResourceProduction.add(building.Build_Statistic.UP_Capacity);
        }

        //Timer.setTime(building.InConstruction.span);

        //if(building.InConstruction.span.TotalSeconds <= 0 )
        //{
        //    building.GetComponent<MoveTimerText>().Remove();
        //    building.iProduce = building.GetDefaultProduce();
        //    building.InConstruction.active = false;
        //    Debug.Log(building.gameObject.name + " Koniec produkcij");

        //}

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
