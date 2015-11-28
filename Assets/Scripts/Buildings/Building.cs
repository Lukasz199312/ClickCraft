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

    public void Start ()
    {

    }

    public void Produce()
    {
        Build_Statistic.ProgressProduction += (((GlobalTimer)subject).RefreshTime / Build_Statistic.Speed ) * Build_Statistic.UP_HitPoints;
       
       if(Build_Statistic.ProgressProduction >= ResourceProduction.RequiredHitPoints)
       {
           Build_Statistic.ResetProgressProduction(ResourceProduction);
           ResourceProduction.add(Build_Statistic.UP_Capacity);
       }
    }

    public void InitializeProduction()
    {
        Debug.Log("B: " + Build_Statistic.Speed);

        Build_Statistic.ResetAllStatistic();
        double TotalMilliseconds = ((GlobalTimer)subject).getTimeSpan().TotalMilliseconds;

        double result = TotalMilliseconds / Build_Statistic.Speed;
        result *= Build_Statistic.HitPoints;
        result /= ResourceProduction.RequiredHitPoints;

        double resultRest = result - (int)result;

        result = (int)result * Build_Statistic.UP_Capacity;
        ResourceProduction.add((int)result);
        Build_Statistic.ProgressProduction = Build_Statistic.ProgressProduction + (resultRest * ResourceProduction.RequiredHitPoints);

        Build_Statistic.ProgressProduction = (double)decimal.Round((decimal)Build_Statistic.ProgressProduction, 2);

        Debug.Log("Czas Poczatkowy: " + ((GlobalTimer)subject).getTimeNow());
        Debug.Log("Czas od ostatniego uruchomienia: " + ((GlobalTimer)subject).getLastRun());

        Debug.Log("Ticks roznica: " + TotalMilliseconds);
        Debug.Log("Wynik produkcji : " + result);
        Debug.Log("reszta: " + resultRest);


    }

    public virtual void Act(object arg) { }
}
