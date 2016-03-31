using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmployeeManager
{
    public bool isStandard = true;
    private int MaxSize;
    private List<Employee> Employees = new List<Employee>();

    public void add(Employee emplo)
    {
        Employees.Add(emplo);
        emplo.Owner = this;
        HumanResource.sub();
    }

    public void Remove(Employee emplo)
    {
        Employees.Remove(emplo);
    }


    public Employee getLazyEmploye()
    {
        IEnumerator<Employee> iter = Employees.GetEnumerator();

        while(iter.MoveNext())
        {
            Employee emplo = (Employee)iter.Current;

            if (emplo.Share == false) return emplo;
        }

        return Employees[Employees.Count - 1];

    }

    private void Share(Employee emplo)
    {
        Employees.Add(emplo);
        emplo.WorkPlace = this;
        emplo.Share = true;
    }


    public static void Share(Employee employee, EmployeeManager WorkPlace)
    {
        WorkPlace.Share(employee);
    }


    public int getCount()
    {
        return Employees.Count;
    }

    public void setMaxSize(int Value)
    {
        MaxSize = Value;
    }

    public int getMaxSize()
    {
        return MaxSize;
    }

    public List<Employee> getList()
    {
        return Employees;
    }


    public static void BackToOwnerAll(EmployeeManager Employees)
    {

        for(int i = Employees.getList().Count - 1; i >= 0; i--)
        {
            Employees.getList()[i].Share = false;

            if (Employees.getList()[i].WorkPlace == null) continue;
            Employees.getList()[i].WorkPlace.getList().Remove(Employees.getList()[i]);
        }
        
    }

    public static void KillAll(EmployeeManager Employees)
    {
        HumanResource.add(Employees.getList().Count);
        Employees.getList().Clear();
    }

}
