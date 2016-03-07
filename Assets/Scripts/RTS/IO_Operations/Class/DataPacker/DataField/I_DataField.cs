using System;

public interface I_DataField
{
     void Unpack(BuildingData _BData, String Data);
     String Pack(BuildingData _BData);
}
