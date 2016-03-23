using UnityEngine;
using System.Collections;

public class HouseType : BuildingType {

    public int NumberPersonOnHuse = 1;

	// Use this for initialization
	void Start () {
        UpdateWokrerOnHouse();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void UpdateWokrerOnHouse()
    {
        HumanResource.setMax( Builds.Count *  NumberPersonOnHuse);
    }

}
