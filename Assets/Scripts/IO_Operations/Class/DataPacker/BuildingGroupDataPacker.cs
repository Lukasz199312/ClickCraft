using UnityEngine;
using System.Collections;
using System;

public class BuildingGroupDataPacker : DataPacker {

    public override object Unpack(object ob, object Data)
    {
        if (ob is string == false) throw new System.ArgumentException("Invalid Type");
        BuildingType buildingtype = (BuildingType)Data;
        for (int i = buildingtype.Builds.Count; i < Convert.ToInt32(ob); i++)
        {
            buildingtype.AddBuild();
        }

        return false;
    }

    public override string Pack(object ob)
    {
        if (ob is BuildingType == false) throw new System.ArgumentException("Invalid Type");
        return ((BuildingType)ob).Builds.Count.ToString();
    }

}
