using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Class describing group of buildings, Storing all group members
/// </summary>
public abstract class BuildingType : MonoBehaviour {

    public List<Building> Builds;
    public Building _Buildnig;
    public int MaxBuilding;
    public int MaxSizeEmployees;
    public BasicProfil Profil;

    private string BuildTypeName = "";
    //private List<Upgrade> UpgradesList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Building AddBuild()
    {
        if (Builds.Count > MaxBuilding) return null;
        // DO WYDZIELENIA DO OSOBNEK KLASY
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = this.gameObject.name + " - " + Builds.Count;
        newBuilding.Index = Builds.Count;
        newBuilding.gameObject.SetActive(true);


        return newBuilding;
    }

    public Building AddBuild(Vector3 Position)
    {
        if (Builds.Count > MaxBuilding) return null;
        // DO WYDZIELENIA DO OSOBNEK KLASY
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = this.gameObject.name + " - " + Builds.Count;
        newBuilding.Index = Builds.Count;
        newBuilding.gameObject.SetActive(true);
        newBuilding.transform.position = new Vector3(Position.x, Position.y, Position.z);


        return newBuilding;
    }

    public Building Initialize()
    {
        Building newBuilding = (Building)Instantiate(this._Buildnig);
        Builds.Add(newBuilding);
        newBuilding.gameObject.transform.parent = gameObject.transform;

        newBuilding.gameObject.name = newBuilding.BuildName + " - " + Builds.Count;
        newBuilding.Index = Builds.Count;

        newBuilding.gameObject.SetActive(true);


        return newBuilding;
    }

    private void CreateBuild()
    {

    }

    public void RemoveBuild(Building Build)
    {
        bool Dec = false;
        IEnumerator<Building> ienum = Builds.GetEnumerator();

        while(ienum.MoveNext())
        {
            Building tmpBuild = (Building)ienum.Current;
            
            if(Dec == false)
            {
                if (tmpBuild.Index == Build.Index)
                {
                    Dec = true;
                    IO_Basic.Delete(Builds[Builds.Count - 1].gameObject.name);
                }
            }
            else
            {
                tmpBuild.Index = tmpBuild.Index - 1;
                tmpBuild.gameObject.name = tmpBuild.BuildName + " - " + tmpBuild.Index;
            }

        }

        Builds.Remove(Build);

        
    }

    public bool isLimitStatusAvalible()
    {
        if (Builds.Count > MaxBuilding) return false;
        else return true;
    }


}
