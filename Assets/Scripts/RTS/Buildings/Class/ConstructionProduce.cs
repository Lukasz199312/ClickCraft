using UnityEngine;
using System.Collections;
using System;

public class ConstructionProduce : I_Produce
{
    private Builder builder;
    private DisplayTimer Timer;

    public ConstructionProduce()
    {
        GameObject ob = GameObject.Find("Builder");
        if (ob != null) builder = ob.GetComponent<Builder>();
        else Debug.LogError("Cant Find Builder");
    }

    public void StartProduce(Building building)
    {
        building.InConstruction.SubtractMilliseconds(((GlobalTimer)building.subject).RefreshTime);

        Timer.setTime(building.InConstruction.span);

        if(building.InConstruction.span.TotalSeconds <= 0 )
        {
            building.GetComponent<MoveTimerText>().Remove();
            building.iProduce = building.GetDefaultProduce();
            building.InConstruction.active = false;
            Debug.Log(building.gameObject.name + " Koniec produkcij");

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
