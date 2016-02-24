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

    public void Start ()
    {
        iProduce = new NormalProduce();
        initializeProduce = new InitializeNormalProduction();
    }

    public void Produce()
    {
        iProduce.Start(this);
    }

    public void InitializeProduction()
    {
        initializeProduce.InitializeProduction(this);
    }


    public virtual void Act(object arg) { }
}
