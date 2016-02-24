using UnityEngine;
using System.Collections;

public class Farm : Building {

    void Start()
    {
        if (InConstruction.active == true)
        {
            Debug.Log("ACTIVE TEST");
            iProduce = new ConstructionProduce();
            initializeProduce = new InitializeConstructionProduction();
        }
        else
        {
            Debug.Log("FALSE TEST");
            iProduce = new NormalProduce();
            initializeProduce = new InitializeNormalProduction();
        }
    }

	// Update is called once per frame
	void Update () {
	
	}

}
