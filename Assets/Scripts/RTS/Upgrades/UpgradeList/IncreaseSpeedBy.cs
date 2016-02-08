using UnityEngine;
using System.Collections;

public class IncreaseSpeedBy : BasicUpgrade {

    public override void UpdateStatus()
    {
        Debug.Log("Aktualizacja stanu: " + gameObject.name);
        _BuildingStatistic.UP_Speed += Value;
    }
}
