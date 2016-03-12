using UnityEngine;
using System.Collections;
using System;

public class SawmillProduce : I_Produce
{
    private Lumberjack Lumber;
    private DisplayTimer Timer;
    private TreeType Trees;

    public SawmillProduce()
    {
        GameObject ob = GameObject.Find("Lumberjack");
        if (ob != null) Lumber = ob.GetComponent<Lumberjack>();
        else Debug.LogError("Cant Find Lumberjack");
    }

    public void StartProduce(Building building)
    {
        if (isNoEmployees(building)) return;

        IEnumerator iter = Trees.Builds.GetEnumerator();

        while(iter.MoveNext())
        {
            Tree tree = (Tree)iter.Current;
            


            if(isTreeEmployeeFull(tree.Employees) == false)
            {
                tree.Employees.add(building.Employees, tree.Employees);
                if (isNoEmployees(building)) return;
            }
            
        }
        
    }

    private bool isNoEmployees(Building building)
    {
        if (building.Employees.getCount() <= 0) return true;
        else return false;
    }

    private bool isTreeEmployeeFull(EmployeeManager emplo)
    {
        if (emplo.getCount() >= emplo.getMaxSize()) return true;
        else return false;
    }
    
    private bool isNull(object ob)
    {
        if (ob != null) return false;
        else return true;
    }

    public void setTimer(DisplayTimer Timer)
    {
        this.Timer = Timer;
    }

    public DisplayTimer getTimer()
    {
        return Timer;
    }

    public void setTreeType(TreeType Tree)
    {
        Trees = Tree;
    }
 
}
