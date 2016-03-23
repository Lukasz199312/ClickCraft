using System;
using UnityEngine;

[System.Serializable]
public class Capacity : I_Resource
{
    private int _Capacity;
    private int Max;
    private Sprite sprite;
    private float DropChance = 1;

    public Capacity(int value, Sprite sprt)
    {
        _Capacity = value;
    }

    public void set(int Value)
    {
        _Capacity = Value;
    }


    public int subCapacty(int Value)
    {
        _Capacity -= Value;
        return _Capacity;
    }

    public void add(int value)
    {
        subCapacty(value);
    }

    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public Sprite getSprite()
    {
        return sprite;
    }

    public float getDropChance()
    {
        return DropChance;
    }

    public int get()
    {
        return _Capacity;
    }

    public void setMax(int Value)
    {
        Max = Value;
    }

    public int getMax()
    {
        return Max;
    }
}