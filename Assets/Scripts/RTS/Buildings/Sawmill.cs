using UnityEngine;
using System.Collections;

public class Sawmill : Building {

    TreeType Trees;

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {

	}

    public override void Initialize()
    {
        if (InConstruction.active == true)
        {
            iProduce = new ConstructionProduce();
            initializeProduce = new InitializeConstructionProduction();
            MoveTimerText moveTimer = this.gameObject.AddComponent<MoveTimerText>();
            moveTimer.Initialize();
            ((ConstructionProduce)iProduce).setTimer(moveTimer.getTimer());

        }
        else
        {
            iProduce = new TreeProduce();
            initializeProduce = new InitializeTreeProduction();
        }
    }
}
