using UnityEngine;
using System.Collections;

public class InitializeConstructionProduction : I_InitializeProduce {

    private Builder builder;

    public InitializeConstructionProduction()
    {
        GameObject ob = GameObject.Find("Builder");
        if (ob != null) builder = ob.GetComponent<Builder>();
        else Debug.LogError("Cant Find Builder");
    }

    public void InitializeProduction(Building building)
    {
        double result = (((GlobalTimer)building.subject).RefreshTime / builder._AutoStatistic.Speed) * builder._AutoStatistic.HitPoints;
        building.InConstruction.addMilliseconds(result);
    }
}
