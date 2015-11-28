using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BuildingDataPacker : DataPacker {

    public override object Unpack(object ob, object Data)
    {
        if (ob is string == false) throw new System.ArgumentException("Invalid Type");
        if (Data is BuildingData == false) throw new System.ArgumentException("Invalid Type");

        string Loaded_Data = (string)ob;
        BuildingData _Building = (BuildingData)Data;

        Debug.Log("Percent Upgrade: " + _Building._UpgradeSystem.PercentUpgrades.Count);
        
        List<string> ChainData = getChainData(Loaded_Data);
        InitializeLoadedData(_Building, ChainData);
        return null;
    }

    public override string Pack(object ob)
    {
        if (ob is BuildingData == false) throw new System.ArgumentException("Invalid Type");
        BuildingData _BuildingData = (BuildingData)ob;

        string strData;
        strData = _BuildingData._Building.Build_Statistic.ProgressProduction.ToString();

        strData = strData + getStringDataToSave(_BuildingData._UpgradeSystem.Upgrades);
        strData = strData + getStringDataToSave(_BuildingData._UpgradeSystem.PercentUpgrades) + ":";

        Debug.Log("BUILD DATA: " + strData);

        return strData;
    }

    private string getStringDataToSave(List<BasicUpgrade> _BasicUpgrade)
    {
        string strData = "";
        foreach (BasicUpgrade Upgrade in _BasicUpgrade)
        {
            strData += ":" + Upgrade.UpgradeLevel;
            Debug.Log("Load string data testL " + Upgrade.UpgradeLevel);
        }

        return strData;
    }

    private List<string> getChainData(string Data)
    {
        List<string> ChainData = new List<string>();
        string DataPart = "";
        
        for(int i = 0; i < Data.Length; i++)
        {
            string tmp_Data = Data.Substring(i, 1);
            if (tmp_Data == ":")
            {
                ChainData.Add(DataPart);
                DataPart = "";
            }
            else DataPart += tmp_Data;
        }

        return ChainData;
    }

    private void InitializeLoadedData(BuildingData _Building, List<string>ChainData)
    {
        int index = 1;
        for (int i = 0; i < _Building._UpgradeSystem.Upgrades.Count; i++, index++)
        {
            _Building._UpgradeSystem.Upgrades[i].UpgradeLevel = Convert.ToInt32(ChainData[index]);
        }

        for (int i = 0; i < _Building._UpgradeSystem.PercentUpgrades.Count; i++, index++)
        {
            _Building._UpgradeSystem.PercentUpgrades[i].UpgradeLevel = Convert.ToInt32(ChainData[index]);
        }
    }
}


//UP_Speed : UP_HitPoints : ProgressProdction : UP_Capacity : Upgrade_LEVEL