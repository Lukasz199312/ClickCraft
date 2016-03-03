using System;
using UnityEngine;

public interface I_Resource
{
    void add(int value);
    void setSprite(Sprite sprite);
    Sprite getSprite();
    float getDropChance();
}
