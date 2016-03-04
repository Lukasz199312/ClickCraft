using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BuildingDataPacker : DataPacker {

    public override object Unpack(object ob, object Data)
    {
        Debug.Log("TEST Load");

        if (ob is string == false) throw new System.ArgumentException("Invalid Type");
        if (Data is BuildingData == false) throw new System.ArgumentException("Invalid Type");

        string Loaded_Data = (string)ob;
        BuildingData _Building = (BuildingData)Data;

       // Debug.Log("Percent Upgrade: " + _Building._UpgradeSystem.PercentUpgrades.Count);
        
        List<string> ChainData = getChainData(Loaded_Data);
        InitializeLoadedData(_Building, ChainData);
        return null;
    }

    public override string Pack(object ob)
    {
        if (ob is BuildingData == false) throw new System.ArgumentException("Invalid Type");
        BuildingData _BuildingData = (BuildingData)ob;

        string strData;
        strData = _BuildingData._Building.Build_Statistic.ProgressProduction.ToString() + ";";

        strData = strData + _BuildingData.PlaceToGrid.Col + ";" + _BuildingData.PlaceToGrid.Row + ";";
        strData = strData + Convert.ToInt32(_BuildingData.PlaceToGrid.scale) + ";" ;

        if (_BuildingData._Building.InConstruction.active == true)
        {
            if (_BuildingData._Building.InConstruction.span.TotalSeconds == 0) _BuildingData._Building.InConstruction.FirstInitialize();
            strData = strData + _BuildingData._Building.InConstruction.span;
        }
        else strData = strData + 0;

       // strData = strData + getStringDataToSave(_BuildingData._UpgradeSystem.Upgrades);
       // strData = strData + getStringDataToSave(_BuildingData._UpgradeSystem.PercentUpgrades) + ":";

        strData += ";";
       // Debug.Log("BUILD DATA: " + strData);

        return strData;
    }

    private string getStringDataToSave(List<BasicUpgrade> _BasicUpgrade)
    {
        string strData = "";
        foreach (BasicUpgrade Upgrade in _BasicUpgrade)
        {
            strData += ";" + Upgrade.UpgradeLevel;
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
            if (tmp_Data == ";")
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
        int index = 4;

        _Building._Building.Build_Statistic.ProgressProduction = float.Parse(ChainData[0]);
        _Building.PlaceToGrid.Col = int.Parse(ChainData[1]);
        _Building.PlaceToGrid.Row = int.Parse(ChainData[2]);
        if (Convert.ToBoolean(int.Parse(ChainData[3])) == true) _Building.PlaceToGrid.MirrorScale();

        if (ChainData[4].Length > 1)
        {
            _Building._Building.InConstruction.span = TimeSpan.Parse(ChainData[4]);
            _Building._Building.InConstruction.active = true;
        }
        else _Building._Building.InConstruction.active = false;

        _Building._Building.Initialize();

        //for (int i = 0; i < _Building._UpgradeSystem.Upgrades.Count; i++, index++)
        //{
        //    _Building._UpgradeSystem.Upgrades[i].UpgradeLevel = Convert.ToInt32(ChainData[index]);
        //}

        //for (int i = 0; i < _Building._UpgradeSystem.PercentUpgrades.Count; i++, index++)
        //{
        //    _Building._UpgradeSystem.PercentUpgrades[i].UpgradeLevel = Convert.ToInt32(ChainData[index]);
        //}

  
    }
}


//UP_Speed ; UP_HitPoints ; ProgressProdction ; UP_Capacity ; Upgrade_LEVEL