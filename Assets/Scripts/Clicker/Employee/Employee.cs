using System;
using System.Collections.Generic;

public class Employee
{
    public EmployeeManager Owner;
    public EmployeeManager WorkPlace;
    public bool Busy;

    public Employee(EmployeeManager _Owner, EmployeeManager _WorkPlace)
    {
        Owner = _Owner;
        WorkPlace = _WorkPlace;
        setStatus(true);
    }

    public Employee(EmployeeManager _Owner)
    {
        Owner = _Owner;
        setStatus(true);
    }

    public void setStatus(bool status)
    {
        Busy = status;
    }

}
