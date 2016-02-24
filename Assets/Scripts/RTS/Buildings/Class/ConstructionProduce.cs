﻿using UnityEngine;
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
        double result = (((GlobalTimer)building.subject).RefreshTime / builder._AutoStatistic.Speed) * builder._AutoStatistic.HitPoints;
        building.InConstruction.addMilliseconds(result);

    }
}
