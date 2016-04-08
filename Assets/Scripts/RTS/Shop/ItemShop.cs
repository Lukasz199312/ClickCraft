using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemShop : MonoBehaviour {
    public int Gold;
    public int Wood;
    public int Stone;
    public int ObsydianBrick;

    public SpriteRenderer Sprite;
    public BuildingType DefaultGroup;
    public PlacingToGrid PlaceToGrid;
    public BuildRecipe Recipe = new BuildRecipe();

    void Start ()
    {
        DefaultGroup = GetComponent<Building>().DefaultGrup;
    }

    public PlacingToGrid GetPlacingToGrid()
    {
        return PlaceToGrid;
    }
}
