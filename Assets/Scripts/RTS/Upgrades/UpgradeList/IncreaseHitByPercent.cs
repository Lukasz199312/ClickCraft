using UnityEngine;
using System.Collections;

public class IncreaseHitByPercent : BasicUpgrade
{
    public override void UpdateStatus()
    {
        Debug.Log("Aktualizacja stanu: " + gameObject.name);
    }
}
