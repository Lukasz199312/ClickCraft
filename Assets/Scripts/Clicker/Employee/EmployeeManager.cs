using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeManager
{
    [SerializeField]
    private int MaxSize;
    private List<Employee> Employees = new List<Employee>();

    public bool add(EmployeeManager Owner, EmployeeManager WorkPlace)
    {
        if (Employees.Count >= MaxSize) return false;

        Employees.Add(new Employee(Owner, WorkPlace));
        return true;
    }

    public bool add(EmployeeManager WorkPlace)
    {
        if (Employees.Count >= MaxSize) return false;

        HumanResource.sub();
        Employees.Add(new Employee(WorkPlace));
        return true;
    }

    public bool Remove()
    {
        if (Employees.Count <= 0) return false;

        HumanResource.add();
        Employees.RemoveAt(Employees.Count - 1);
        return true;
    }

    public bool RemoveAll()
    {
        if (Employees.Count <= 0) return false;

        HumanResource.add(Employees.Count);
        Employees.Clear();
        return true;
    }

    public bool BackToOwner()
    {
        if (Employees.Count <= 0) return false;
        if (Employees[Employees.Count - 1].Owner != null) return false;

        Employees[Employees.Count - 1].Owner.add(Employees[Employees.Count - 1].WorkPlace);
        Employees[Employees.Count - 1].WorkPlace.Remove();
        return true;

    }

    public bool ReleaseAll()
    {
        if (Employees.Count <= 0) return false;
        IEnumerator<Employee> iter = Employees.GetEnumerator();

        while(iter.MoveNext())
        {
            Employee emplo = iter.Current;

            emplo.Owner.add(emplo.WorkPlace);
            emplo.WorkPlace.Remove();
        }
        return true;
    }

    public int getCount()
    {
        return Employees.Count;
    }

}
