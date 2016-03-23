using UnityEngine;
using System;

public class CollectProduceItem : I_TouchaActions
{
    public Building Build;

    public CollectProduceItem(Building Build)
    {
        this.Build = Build;
    }

    public void DoAction()
    {
        Build.ResourceProduction.add((int)Build.Build_Statistic.Capacity);
        Build.Build_Statistic.Capacity = 0;

        Build.InCollectMode = false;
        Build.GetComponent<MoveItemCollect>().Remove();
        Build.GetComponent<TouchedObject>().InitializeAsMenu();

        Camera.main.gameObject.GetComponent<TouchController>().DisableDoubleTouch = false;
        Debug.Log("MAIN: " + Camera.main.gameObject.GetComponent<TouchController>().DisableDoubleTouch);
        
        
    }
}

