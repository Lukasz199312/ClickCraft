using UnityEngine;
using System.Collections;

public class Randomness {

    public bool Generate(float PercentChance)
    {
        float result = Random.value;

        if (result <= PercentChance) return true;
        else return false;
    }

}
