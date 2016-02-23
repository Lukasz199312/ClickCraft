using UnityEngine;
using System.Collections;

public class House : Building {

	// Use this for initialization
	void Start () {
        if (InConstruction.active == true) iProduce = new ConstructionProduce();
        else iProduce = new NormalProduce();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
