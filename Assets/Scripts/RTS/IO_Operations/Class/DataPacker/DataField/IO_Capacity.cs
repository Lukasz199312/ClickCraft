using System;

public class IO_Capacity : I_DataField
{
    public void Unpack(BuildingData _BData, string Data)
    {
        ((Tree)_BData._Building).Capacity.set(Convert.ToInt32(Data));
    }

    public string Pack(BuildingData _BData)
    {
        return ((Tree)_BData._Building).Capacity.get().ToString();
    }
}

