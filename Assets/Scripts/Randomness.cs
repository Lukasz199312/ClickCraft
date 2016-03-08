using UnityEngine;
using System.Collections;

public class Randomness {

    public bool Generate(float PercentChance)
    {
        float result = Random.value;

        if (result <= PercentChance) return true;
        else return false;
    }


    public void SceneGenerateResourceValue(ClickerScene Scene, Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            I_Resource[] Resources = Scene.Profil.getResources();
            ClickerStatistic Statistic = Scene.Profil._ClickerStatistic;
            bool result = false;

            for (int i = Resources.Length - 1; i > 0; i--)
            {
                result = Generate(Resources[i].getDropChance());
                if (result == true)
                {
                    if (Statistic.ClickCric >= Statistic.DefaultClick && Generate(Statistic.CriticalChance) == true)
                    {
                        int Value = Scene.Profil.getRandomHitValue();
                        Value = Value + Value * (int)Scene.Profil._ClickerStatistic.CriticalBonus;

                        Scene.ClickActionCric(Value, Resources[i].getSprite(), Resources[i]);
                        Statistic.ClickCric = 0;
                        break;
                    }
                    else
                    {
                        int Value = Scene.Profil.getRandomHitValue();

                        Scene.ClickActionSpecial(Value, Resources[i].getSprite(), Resources[i]);
                        Statistic.ClickCric++;
                        break;
                    }

                }
            }

            if (result == false)
            {
                if (Statistic.ClickCric >= Statistic.DefaultClick && Generate(Statistic.CriticalChance) == true)
                {
                    int Value = Scene.Profil.getRandomHitValue();
                    Value = Value + Value * (int)Scene.Profil._ClickerStatistic.CriticalBonus;

                    Scene.ClickActionCric(Value, Resources[0].getSprite(), Resources[0]);
                    Statistic.ClickCric = 0;
                }
                else
                {
                    int Value = Scene.Profil.getRandomHitValue();

                    Scene.ClickAction(Value, Resources[0]);
                    Statistic.ClickCric++;
                }

            }

        }
    }


}
