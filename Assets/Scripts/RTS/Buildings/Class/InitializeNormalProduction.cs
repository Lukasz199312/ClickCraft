using UnityEngine;
using System.Collections;

public class InitializeNormalProduction : I_InitializeProduce {

    public void InitializeProduction(Building building)
    {
        BuildingStatistic Build_Statistic = building.Build_Statistic;
        Resource ResourceProduction = building.ResourceProduction;

        Debug.Log("B;" + Build_Statistic.Speed);

        Build_Statistic.ResetAllStatistic();
        double TotalMilliseconds = ((GlobalTimer)building.subject).getTimeSpan().TotalMilliseconds;

        double result = TotalMilliseconds / Build_Statistic.Speed;
        result *= Build_Statistic.HitPoints;
        result /= ResourceProduction.RequiredHitPoints;

        double resultRest = result - (int)result;
        resultRest = (double)decimal.Round((decimal)resultRest, 2);

        result = (int)result * Build_Statistic.UP_Capacity;
        ResourceProduction.add((int)result);
        Build_Statistic.ProgressProduction = Build_Statistic.ProgressProduction + (resultRest * ResourceProduction.RequiredHitPoints);

        Build_Statistic.ProgressProduction = (double)decimal.Round((decimal)Build_Statistic.ProgressProduction, 2);

        Debug.Log("Czas Poczatkowy; " + ((GlobalTimer)building.subject).getTimeNow());
        Debug.Log("Czas od ostatniego uruchomienia; " + ((GlobalTimer)building.subject).getLastRun());

        Debug.Log("Ticks roznica; " + TotalMilliseconds);
        Debug.Log("Wynik produkcji ; " + result);
        Debug.Log("reszta: " + resultRest);
    }
}
