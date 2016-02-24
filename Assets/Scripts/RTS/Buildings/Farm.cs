using UnityEngine;
using System.Collections;

public class Farm : Building {

    void Start()
    {
      //  iProduce = new ConstructionProduce();
        iProduce = new NormalProduce();
        initializeProduce = new InitializeNormalProduction();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public override void Act(object arg)
    {
        base.Act(arg);
    }
}
