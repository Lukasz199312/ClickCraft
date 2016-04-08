using UnityEngine;
using System.Collections;

public enum RecipeType
{
    HOUSE,
    SAWMILL,
    FARM,
    TRAINING_GROUND,
    TREE
};

public class BuildRecipe : MonoBehaviour {

    public SimpleData simpladata;

    [SerializeField]
    public int Cost;
    [SerializeField]
    public RecipeType Type;

    public bool CheckAfford()
    {
        if ((int)simpladata.Value >= Cost) return true;
        else return false;
    }
}
