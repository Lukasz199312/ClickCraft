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
    public BuildTime InConstruction =  new BuildTime();

    public void Start ()
    {
        iProduce = new NormalProduce();
    }

    public void Produce()
    {
        iProduce.Start(this);
    }

    public void InitializeProduction()
    {
        Debug.Log("B;" + Build_Statistic.Speed);

        Build_Statistic.ResetAllStatistic();
        double TotalMilliseconds = ((GlobalTimer)subject).getTimeSpan().TotalMilliseconds;

        double result = TotalMilliseconds / Build_Statistic.Speed;
        result *= Build_Statistic.HitPoints;
        result /= ResourceProduction.RequiredHitPoints;

        double resultRest = result - (int)result;
        resultRest = (double)decimal.Round((decimal)resultRest, 2);

        result = (int)result * Build_Statistic.UP_Capacity;
        ResourceProduction.add((int)result);
        Build_Statistic.ProgressProduction = Build_Statistic.ProgressProduction + (resultRest * ResourceProduction.RequiredHitPoints);

        Build_Statistic.ProgressProduction = (double)decimal.Round((decimal)Build_Statistic.ProgressProduction, 2);

        Debug.Log("Czas Poczatkowy; " + ((GlobalTimer)subject).getTimeNow());
        Debug.Log("Czas od ostatniego uruchomienia; " + ((GlobalTimer)subject).getLastRun());

        Debug.Log("Ticks roznica; " + TotalMilliseconds);
        Debug.Log("Wynik produkcji ; " + result);
        Debug.Log("reszta: " + resultRest);


    }


    public virtual void Act(object arg) { }
}
