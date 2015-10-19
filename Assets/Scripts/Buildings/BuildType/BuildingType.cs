using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BuildingType : MonoBehaviour {

    public List<Building> Builds;
    public Building _Buildnig;

    private string BuildTypeName = "";
    private List<Upgrade> UpgradesList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddBuild()
    {
        // DO WYDZIELENIA DO OSOBNEK KLASY
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = this.gameObject.name + " - " + Builds.Count;
        newBuilding.gameObject.SetActive(true);
    }
}
