﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class BuildingStatistic {

    public float Speed;
    public float HitPoints;
    public double ProgressProduction;
    public float Capacity; // okresla ilosc dodawanych produktow

    public float UP_Speed;
    public float UP_HitPoints;
    public double UP_ProgressProduction;
    public float UP_Capacity; 

    public BuildingStatistic()
    {
        ResetAllStatistic();
    }

    public void ResetProgressProduction()
    {
        ProgressProduction = 0;
    }

    public void ResetProgressProduction(Resource resource)
    {
        ProgressProduction = ProgressProduction - resource.RequiredHitPoints;
        ProgressProduction = (double)decimal.Round((decimal)ProgressProduction, 2);
    }

    public void ResetAllStatistic()
    {
        UP_Speed = Speed;
        UP_HitPoints = HitPoints;
        UP_ProgressProduction = (double)decimal.Round((decimal)ProgressProduction, 2);
        UP_Capacity = Capacity;
    }
}
