﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Class describing group of buildings, Storing all group members
/// </summary>
public abstract class BuildingType : MonoBehaviour {

    public List<Building> Builds;
    public Building _Buildnig;

    private string BuildTypeName = "";
    private int Index;
    //private List<Upgrade> UpgradesList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Building AddBuild()
    {
        // DO WYDZIELENIA DO OSOBNEK KLASY
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = this.gameObject.name + " - " + Builds.Count;
        newBuilding.gameObject.SetActive(true);

        Index++;

        return newBuilding;
    }

    public Building AddBuild(Vector3 Position)
    {
        // DO WYDZIELENIA DO OSOBNEK KLASY
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = this.gameObject.name + " - " + Builds.Count;
        newBuilding.gameObject.SetActive(true);
        newBuilding.transform.position = new Vector3(Position.x, Position.y, Position.z);

        Index++;

        return newBuilding;
    }

    public Building Initialize()
    {
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = this.gameObject.name + " - " + Builds.Count;
        newBuilding.gameObject.SetActive(true);

        Index++;

        return newBuilding;
    }

    private void CreateBuild()
    {

    }

    public void RemoveBuild(Building Build)
    {
        Builds.Remove(Build);
    }

    public int getIndex()
    {
        return Index;
    }

    public void setIndex(int index)
    {
        this.Index = index;
    }

}
