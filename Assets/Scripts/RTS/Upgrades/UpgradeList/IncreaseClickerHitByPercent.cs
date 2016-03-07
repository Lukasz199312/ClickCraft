using UnityEngine;
using System.Collections;

public class IncreaseClickerHitByPercent : BasicUpgrade
{
    public override void UpdateStatus()
    {
        Debug.Log("Aktualizacja stanu: " + gameObject.name);
        Profil._ClickerStatistic.MinHit += (int)(Profil._ClickerStatistic.MinHit * Value);
        Profil._ClickerStatistic.MaxHit += (int)(Profil._ClickerStatistic.MaxHit * Value);
    }
}
