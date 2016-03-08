using System;
using System.Collections.Generic;

public class Employee
{
    public EmployeeManager Owner;
    public EmployeeManager WorkPlace;

    public Employee(EmployeeManager _Owner, EmployeeManager _WorkPlace)
    {
        Owner = _Owner;
        WorkPlace = _WorkPlace;
    }

    public Employee(EmployeeManager _Owner)
    {
        Owner = _Owner;
    }

}
