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
            Resource[] Resources = Scene.Profil.getResources();
            ClickerStatistic Statistic = Scene.Profil._ClickerStatistic;
            bool result = false;

            for (int i = Resources.Length - 1; i > 0; i--)
            {
                result = Generate(Resources[i].DropChance);
                if (result == true)
                {
                    if (Statistic.ClickCric >= Statistic.DefaultClick && Generate(Statistic.CriticalChance) == true)
                    {
                        int Value = Scene.Profil.getRandomHitValue();
                        Value = Value + Value * (int)Scene.Profil._ClickerStatistic.CriticalBonus;

                        Resources[i].add(Value);
                        Scene.ClickActionCric(Value, Resources[i].sprite);
                        Statistic.ClickCric = 0;
                        break;
                    }
                    else
                    {
                        int Value = Scene.Profil.getRandomHitValue();

                        Resources[i].add(Value);
                        Scene.ClickActionSpecial(Value, Resources[i].sprite);
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

                    Resources[0].add(Value);
                    Scene.ClickActionCric(Value, Resources[0].sprite);
                    Statistic.ClickCric = 0;
                }
                else
                {
                    int Value = Scene.Profil.getRandomHitValue();

                    Resources[0].add(Value);
                    Scene.ClickAction(Value);
                    Statistic.ClickCric++;
                }

            }

        }
    }


    public void SceneGeneratorTime(ClickerScene Scene, Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            Resource[] Resources = Scene.Profil.getResources();
            ClickerStatistic Statistic = Scene.Profil._ClickerStatistic;
            bool result = false;

            for (int i = Resources.Length - 1; i > 0; i--)
            {
                result = Generate(Resources[i].DropChance);
                if (result == true)
                {
                    if (Statistic.ClickCric >= Statistic.DefaultClick && Generate(Statistic.CriticalChance) == true)
                    {
                        int Value = Scene.Profil.getRandomHitValue();
                        Value = Value + Value * (int)Scene.Profil._ClickerStatistic.CriticalBonus;

                        Resources[i].add(Value);
                        Scene.ClickActionCric(Value, Resources[i].sprite);
                        Statistic.ClickCric = 0;
                        break;
                    }
                    else
                    {
                        int Value = Scene.Profil.getRandomHitValue();

                        Resources[i].add(Value);
                        Scene.ClickActionSpecial(Value, Resources[i].sprite);
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

                    Resources[0].add(Value);
                    Scene.ClickActionCric(Value, Resources[0].sprite);
                    Statistic.ClickCric = 0;
                }
                else
                {
                    int Value = Scene.Profil.getRandomHitValue();

                    Resources[0].add(Value);
                    Scene.ClickAction(Value);
                    Statistic.ClickCric++;
                }

            }

        }
    }

}
