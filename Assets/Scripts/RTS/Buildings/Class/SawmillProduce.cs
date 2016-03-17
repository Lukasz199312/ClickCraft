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
            if (isTreeEmployeeFull(tree.Employees) == true) continue;
            SendToWork(tree, getLazyEmplo(building));
            

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

    private Employee getLazyEmplo(Building build)
    {
        Employee emplo = build.Employees.getLazyEmploye();

        if (emplo.Share == true) return null;
        else return emplo;
    }

    private bool SendToWork(Building build, Employee emplo)
    {
        if (emplo == null) return false;
        EmployeeManager.Share(emplo, build.Employees);

        return true;
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
