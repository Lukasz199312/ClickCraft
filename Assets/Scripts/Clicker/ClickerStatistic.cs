using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClickerStatistic {

    public int MinHit;
    public int MaxHit;

    public float CriticalChance;
    public float CriticalBonus;

    public int DefaultClick;
    public int ClickCric;

    public static ClickerStatistic Copy(ClickerStatistic copyObject)
    {
        ClickerStatistic tmpClicker = new ClickerStatistic();

        tmpClicker.MinHit = copyObject.MinHit;
        tmpClicker.MaxHit = copyObject.MaxHit;

        tmpClicker.CriticalChance = copyObject.CriticalChance;
        tmpClicker.CriticalBonus = copyObject.CriticalBonus;

        tmpClicker.DefaultClick = copyObject.DefaultClick;
        tmpClicker.ClickCric = copyObject.ClickCric;

        return tmpClicker;
    }

}
