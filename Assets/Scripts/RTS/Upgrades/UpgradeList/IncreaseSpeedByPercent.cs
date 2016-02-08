using UnityEngine;
using System.Collections;

public class IncreaseSpeedByPercent : BasicUpgrade
{
    public override void UpdateStatus()
    {
        Debug.Log("Aktualizacja stanu: " + gameObject.name);
    }
}
