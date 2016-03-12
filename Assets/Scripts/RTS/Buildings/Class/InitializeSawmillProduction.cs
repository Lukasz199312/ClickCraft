using UnityEngine;
using System.Collections;

public class InitializeSawmillProduction : I_InitializeProduce {

    private Lumberjack Lumber;
    private TreeType Trees;

    public InitializeSawmillProduction()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) Lumber = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void InitializeProduction(Building building)
    {

    }

    public void setTreeType(TreeType treetype)
    {
        Trees = treetype;
    }
}
