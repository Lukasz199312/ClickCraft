using UnityEngine;
using System.Collections;

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
        double result = (((GlobalTimer)building.subject).RefreshTime / builder._AutoStatistic.Speed) * builder._AutoStatistic.HitPoints;
        building.InConstruction.addMilliseconds(result);

        Timer.TimetText.text = building.InConstruction.Date.ToString();

    }

    public void setTimer(DisplayTimer Timer)
    {
        this.Timer = Timer;
    }
}
