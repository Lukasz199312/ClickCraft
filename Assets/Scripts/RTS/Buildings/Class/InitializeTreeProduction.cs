using UnityEngine;
using System.Collections;

public class InitializeTreeProduction : I_InitializeProduce {

    private Lumberjack builder;

    public InitializeTreeProduction()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) builder = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void InitializeProduction(Building building)
    {
        //double TotalMilliseconds = ((GlobalTimer)building.subject).getTimeSpan().TotalMilliseconds;
        //Debug.Log("******************" + TotalMilliseconds);
       // building.InConstruction.SubtractMilliseconds(TotalMilliseconds);
    }
}
