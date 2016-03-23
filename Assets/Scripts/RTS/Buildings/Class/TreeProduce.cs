using UnityEngine;
using System.Collections;
using System;

public class TreeProduce : I_Produce
{
    private Lumberjack Lumber;
    private DisplayTimer Timer;

    public TreeProduce()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) Lumber = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void StartProduce(Building building)
    {
        if (building.Employees.getCount() <= 0) return;

        foreach (Employee emplo in building.Employees.getList())
        {
            if (IsMax(emplo.OwnerBuild) != true) ProduceStaff(building, emplo.OwnerBuild);
            else StopProduce(emplo.OwnerBuild);
        }
    }

    private bool IsMax(Building OwnerBuild)
    {
        if (OwnerBuild.Build_Statistic.Capacity >= Lumber._AutoStatistic.MaxCapacity) return true;
        else return false;
    }

    private void StopProduce(Building OwnerBuild)
    {
        if (OwnerBuild.Build_Statistic.Capacity > Lumber._AutoStatistic.MaxCapacity)
            OwnerBuild.Build_Statistic.Capacity = Lumber._AutoStatistic.MaxCapacity;

        if (OwnerBuild.InCollectMode == true) return;

        OwnerBuild.gameObject.AddComponent<MoveItemCollect>().Initialize();
        OwnerBuild.gameObject.GetComponent<TouchedObject>().InitializeAsCollectItem();
        OwnerBuild.InCollectMode = true;
    }

    private void ProduceStaff(Building WorkBuild, Building OwnerBuild)
    {
        float result = (((GlobalTimer)WorkBuild.subject).RefreshTime / Lumber._AutoStatistic.Speed) * Lumber._AutoStatistic.HitPoints;
        OwnerBuild.Build_Statistic.Capacity += result;
        ((Tree)WorkBuild).Capacity.add((int)result);

    }

    public void setTimer(DisplayTimer Timer)
    {
        this.Timer = Timer;
    }

    public DisplayTimer getTimer()
    {
        return Timer;
    }

 
}
