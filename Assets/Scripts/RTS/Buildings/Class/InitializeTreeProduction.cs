using UnityEngine;
using System.Collections;

public class InitializeTreeProduction : I_InitializeProduce {

    private Lumberjack Lumber;

    public InitializeTreeProduction()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) Lumber = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void InitializeProduction(Building building)
    {

    }
}
