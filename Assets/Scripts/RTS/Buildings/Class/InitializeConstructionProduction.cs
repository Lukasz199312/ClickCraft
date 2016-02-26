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
        double TotalMilliseconds = ((GlobalTimer)building.subject).getTimeSpan().TotalMilliseconds;
        Debug.Log("******************" + TotalMilliseconds);
        building.InConstruction.SubtractMilliseconds(TotalMilliseconds);
    }
}
