using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemShop : MonoBehaviour {
    public int Gold;
    public int Wood;
    public int Food;
    public SpriteRenderer Sprite;
    public BuildingType DefaultGroup;

    void Start ()
    {
        DefaultGroup = GetComponent<Building>().DefaultGrup;
    }
}
