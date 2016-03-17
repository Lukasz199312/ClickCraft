using System;

public class IO_EmployeeJob : I_DataField
{
    public void Unpack(BuildingData _BData, string Data)
    {

        for (int i = 1; i <= Convert.ToInt32(Data); i++ )
            Employee.IO_Create(_BData._Building.Employees, _BData._Building);
    }

    public string Pack(BuildingData _BData)
    {
        return _BData._Building.Employees.getCount().ToString();
    }
}

