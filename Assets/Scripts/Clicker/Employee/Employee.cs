using System;
using System.Collections.Generic;

public class Employee
{
    public Building Owner;
    public Building WorkPlace;

    public Employee(Building _Owner, Building _WorkPlace)
    {
        Owner = _Owner;
        WorkPlace = _WorkPlace;
    }

    public Employee(Building _Owner)
    {
        Owner = _Owner;
    }

}

