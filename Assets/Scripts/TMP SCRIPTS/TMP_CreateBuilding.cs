using UnityEngine;
using System.Collections;

public class TMP_CreateBuilding : MonoBehaviour {

    public Building BuildingToCreate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddBuilding(BuildingType Group)
    {
        Building newBuilding = Instantiate(BuildingToCreate) as Building;

        newBuilding.gameObject.name = BuildingToCreate.name + " - " + (Group.Builds.Count + 1).ToString() ;
        newBuilding.gameObject.transform.parent = Group.transform;
        newBuilding.gameObject.SetActive(true);
        Group.Builds.Add(newBuilding);
    }
}
