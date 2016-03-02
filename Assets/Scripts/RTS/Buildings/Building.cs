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

    void Start()
    {
       
    }

    public void Produce()
    {
        iProduce.StartProduce(this);
    }

    public void InitializeProduction()
    {
        initializeProduce.InitializeProduction(this);
    }

    public virtual void Initialize()
    {
        if (InConstruction.active == true)
        {
            iProduce = new ConstructionProduce();
            initializeProduce = new InitializeConstructionProduction();
            MoveTimerText moveTimer =  this.gameObject.AddComponent<MoveTimerText>();
            moveTimer.Initialize();
            ((ConstructionProduce)iProduce).setTimer(moveTimer.getTimer());

            
            //GetComponent<TouchedObject>().BuildingActionGUI = tmpBuildActionGui;
        }
        else
        {
            iProduce = new NormalProduce();
            initializeProduce = new InitializeNormalProduction();
        }
    }

    public virtual I_Produce GetDefaultProduce()
    {
        return new NormalProduce();
    }


}
