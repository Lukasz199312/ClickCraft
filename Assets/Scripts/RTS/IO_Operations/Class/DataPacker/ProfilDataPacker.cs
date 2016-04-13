using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class ProfilDataPacker : DataPacker
{

    public override object Unpack(object ob, object Data)
    {
        if (ob is string == false) throw new System.ArgumentException("Invalid Type");
        BasicProfil Profil = (BasicProfil)Data;

        List<string> list = getChainData(ob.ToString());
        Profil.exp.Io_Initialize(Convert.ToInt32(list[1]), Convert.ToInt32(list[0]));

        return false;
    }

    public override string Pack(object ob)
    {
        if (ob is BasicProfil == false) throw new System.ArgumentException("Invalid Type");

        string str = "";
        str = ((BasicProfil)ob).exp.Level + ";" + ((BasicProfil)ob).exp.Experince + ";";
        return str;
    }

    private List<string> getChainData(string Data)
    {
        List<string> ChainData = new List<string>();
        string DataPart = "";

        for (int i = 0; i < Data.Length; i++)
        {
            string tmp_Data = Data.Substring(i, 1);
            if (tmp_Data == ";")
            {
                ChainData.Add(DataPart);
                DataPart = "";
            }
            else DataPart += tmp_Data;
        }

        return ChainData;
    }
}
