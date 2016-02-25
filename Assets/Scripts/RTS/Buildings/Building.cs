using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
///SuperClass representation Building 
/// </summary>
public abstract class Building : Observe {

    public BuildingInformation Building_Information;
    public BuildingStatistic Build_Statistic;
    public Resource ResourceProduction;
    public BuildingType DefaultGrup;
    public int Index;
    public string BuildName;
    public I_Produce iProduce;
    public I_InitializeProduce initializeProduce;
    public BuildTime InConstruction =  new BuildTime();

    public void Produce()
    {
        iProduce.StartProduce(this);
    }

    public void InitializeProduction()
    {
        Debug.Log("GameObject: " + gameObject.name + initializeProduce.ToString());
        initializeProduce.InitializeProduction(this);
        Debug.Log(gameObject.name);
    }

    public virtual void Initialize()
    {
        if (InConstruction.active == true)
        {
            Debug.Log("ACTIVE TEST");
            iProduce = new ConstructionProduce();
            initializeProduce = new InitializeConstructionProduction();
            MoveTimerText moveTimer =  this.gameObject.AddComponent<MoveTimerText>();
            moveTimer.Initialize();

            ((ConstructionProduce)iProduce).setTimer(moveTimer.getTimer());
        }
        else
        {
            Debug.Log("FALSE TEST");
            iProduce = new NormalProduce();
            initializeProduce = new InitializeNormalProduction();
        }
    }
}
