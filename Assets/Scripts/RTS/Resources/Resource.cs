using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resource : MonoBehaviour, I_Resource {

    public SimpleData Value;
    public float RequiredHitPoints;
    public float DropChance;
    public Sprite sprite;
    public bool Specjal = true;

    protected string text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getValue()
    {
        return (int) Value.Value;
    }

    public void add(int value)
    {
        Value.Value = Value.Value + value;
    }

    public void subtract(int value)
    {
        Value.Value = Value.Value - value;
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    float I_Resource.getDropChance()
    {
        return DropChance;
    }
}
