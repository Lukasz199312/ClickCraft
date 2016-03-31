using System;
using System.Collections.Generic;

public class Employee
{
    public EmployeeManager Owner;
    public EmployeeManager WorkPlace;

    public Building OwnerBuild;
    public Building WorkBulding;

    public bool Share;

    private Employee(){}

    public static Employee Create(EmployeeManager Owner, Building OwnerBuild)
    {
        if (HumanResource.getCount() <= 0) return null;
        if (Owner.getCount() >= Owner.getMaxSize()) return null;
        else
        {
            Employee emplo = new Employee();
            emplo.OwnerBuild = OwnerBuild;
            Owner.add(emplo);
            

            return emplo;
        }
    }

    public static Employee IO_Create(EmployeeManager Owner, Building OwnerBuild)
    {
        if (HumanResource.getCount() <= 0) return null;
        if (Owner.getCount() >= Owner.getMaxSize()) return null;
        else
        {
            Employee emplo = new Employee();
            emplo.OwnerBuild = OwnerBuild;
            Owner.add(emplo);

            return emplo;
        }
    }

    public static void Kill(Employee employee)
    {

        if (employee.Owner != null) employee.Owner.Remove(employee);
        if (employee.WorkPlace != null) employee.WorkPlace.Remove(employee);
        if (employee.WorkPlace == null && employee.Owner == null ) return;

        HumanResource.add();
    }


    public static void BackToOwner(Employee employee)
    {
        employee.Share = false;
        employee.WorkPlace.Remove(employee);
    }

    public static void RemoveAll(EmployeeManager WorkPlace)
    {
        if (WorkPlace.getCount() <= 0) return;

        for(int i = 1; i < WorkPlace.getCount(); i++)
        {
            BackToOwner(WorkPlace.getList()[0]);
        }
    }

}
