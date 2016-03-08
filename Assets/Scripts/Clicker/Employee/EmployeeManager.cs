using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeManager
{
    [SerializeField]
    private int MaxSize;
    private List<Employee> Employees = new List<Employee>();

    public  bool set(Building Owner, Building WorkPlace)
    {
        if (getCount() >= MaxSize) return false;

        Employees.Add(new Employee(Owner, WorkPlace));
        return true;
    }

    public  bool set(Building WorkPlace)
    {
        if (getCount() >= MaxSize) return false;

        Employees.Add(new Employee(WorkPlace));
        return true;
    }

    private int getCount()
    {
        return Employees.Count;
    }


}
