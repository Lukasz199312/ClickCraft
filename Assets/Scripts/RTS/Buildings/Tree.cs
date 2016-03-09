using UnityEngine;
using System.Collections;

[System.Serializable]
public class TreeCapacity : I_Resource
{
    private int Capacity;
    private Sprite sprite;
    private float DropChance = 1;

    public TreeCapacity(int value, Sprite sprt)
    {
        Capacity = value;
    }

    public void set(int Value)
    {
        Capacity = Value;
    }


    public int subCapacty(int Value)
    {
        Capacity -= Value;
        return Capacity;
    }

    public void add(int value)
    {
        subCapacty(value);
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    public float getDropChance()
    {
        return DropChance;
    }

    public int get()
    {
        return Capacity;
    }
}

public class Tree : Building
{
    public TreeCapacity Capacity;

    void Awake()
    {
        IO_DataField.Add(new IO_Capacity() );

        Capacity = new TreeCapacity(((TreeType)DefaultGrup).TreeCapacity, ResourceProduction.sprite);

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
        return new NoProduce();
    }

}
