﻿using UnityEngine;
using System.Collections;

public class Farm : Building {

    void Start()
    {
        iProduce = new ConstructionProduce();
    }

	// Update is called once per frame
	void Update () {
	
	}

    public override void Act(object arg)
    {
        base.Act(arg);
    }
}
