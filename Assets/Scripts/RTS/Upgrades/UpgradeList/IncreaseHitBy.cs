using UnityEngine;
using System.Collections;

public class IncreaseHitBy : BasicUpgrade {

    public override void UpdateStatus()
    {
        Debug.Log("Aktualizacja stanu: " + gameObject.name);
       Profil._ClickerStatistic.MinHit += (int)(Value / 2);
       Profil._ClickerStatistic.MaxHit += (int)Value;
    }
}
