﻿using UnityEngine;
using System.Collections;

public class Sawmill : Building {

    public TreeType Trees;

    void Awake()
    {
        IO_DataField.Add(new IO_EmployeeJob());

        subject.Add(this);
        Employees.setMaxSize(DefaultGrup.MaxSizeEmployees);
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
            iProduce = new SawmillProduce();
            ((SawmillProduce)iProduce).setTreeType(Trees);

            initializeProduce = new InitializeSawmillProduction();
            ((InitializeSawmillProduction)initializeProduce).setTreeType(Trees);
        }
    }

    public override I_Produce GetDefaultProduce()
    {
        SawmillProduce sawmilproduce = new SawmillProduce();
        sawmilproduce.setTreeType(Trees);

        return sawmilproduce;
    }

}
