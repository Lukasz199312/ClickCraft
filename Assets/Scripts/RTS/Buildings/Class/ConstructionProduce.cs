using UnityEngine;
using System.Collections;

public class ConstructionProduce : I_Produce {
    private Builder builder;

    public ConstructionProduce()
    {
        GameObject ob = GameObject.Find("Builder");
        if (ob != null) builder = ob.GetComponent<Builder>();
        else Debug.LogError("Cant Find Builder");
    }

    public void Start(Building building)
    {
        building.Build_Statistic.ProgressProduction += (((GlobalTimer)building.subject).RefreshTime / building.Build_Statistic.Speed) * building.Build_Statistic.UP_HitPoints;

        if (building.Build_Statistic.ProgressProduction >= building.ResourceProduction.RequiredHitPoints)
        {
            building.Build_Statistic.ResetProgressProduction(building.ResourceProduction);
            building.ResourceProduction.add(building.Build_Statistic.UP_Capacity);
        }

        building.InConstruction.Reload();
    }
}
