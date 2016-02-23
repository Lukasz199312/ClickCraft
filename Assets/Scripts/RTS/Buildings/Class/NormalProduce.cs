using UnityEngine;
using System.Collections;

public class NormalProduce : I_Produce
{

    public void Start(Building building)
    {
        building.Build_Statistic.ProgressProduction += (((GlobalTimer)building.subject).RefreshTime / building.Build_Statistic.Speed) * building.Build_Statistic.UP_HitPoints;

        if (building.Build_Statistic.ProgressProduction >= building.ResourceProduction.RequiredHitPoints)
        {
            building.Build_Statistic.ResetProgressProduction(building.ResourceProduction);
            building.ResourceProduction.add(building.Build_Statistic.UP_Capacity);
        }
    }
}
