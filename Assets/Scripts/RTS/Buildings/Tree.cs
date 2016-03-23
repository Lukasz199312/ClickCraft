using UnityEngine;
using System.Collections;

public class Tree : Building, I_ResourceBuildFunction
{
    public Capacity Capacity;

    void Awake()
    {
        IO_DataField.Add(new IO_Capacity() );

        Capacity = new Capacity(((TreeType)DefaultGrup).TreeCapacity, ResourceProduction.sprite);
        Capacity.setMax(((TreeType)DefaultGrup).TreeCapacity);

        Employees.setMaxSize(DefaultGrup.MaxSizeEmployees);

        subject.Add(this);
        if (DefaultGrup.name != "Tree")
        {
            Debug.LogError("System Rozjebany!");
            return;
        }
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


            //GetComponent<TouchedObject>().BuildingActionGUI = tmpBuildActionGui;
        }
        else
        {
            iProduce = new TreeProduce();
            initializeProduce = new NoInitializeProduce();
        }
    }

    public override I_Produce GetDefaultProduce()
    {
        return new TreeProduce();
    }


    public Capacity getCapacity()
    {
        return Capacity;
    }
}
