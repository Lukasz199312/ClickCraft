using System;
using System.Collections.Generic;

public static class SpecialDataPacker
{
    public static int StartIndex;

   // public static void Unpack
    public static void Unpack(BuildingData BData, List<string> ChainData)
    {
        List<I_DataField> ListData = BData._Building.getDataField();
        if (ChainData.Count >= StartIndex) return;

        for(int i = 0; i < ListData.Count; i++)
        {
            ListData[i].Unpack(BData, ChainData[i + StartIndex]);
        }
    }

    public static String Pack(BuildingData BData)
    {
        List<I_DataField> ListData = BData._Building.getDataField();
        String TmpData = "";

        foreach (I_DataField Data in ListData)
        {
            TmpData += Data.Pack(BData) + ";";
        }

        return TmpData;
    }
}

