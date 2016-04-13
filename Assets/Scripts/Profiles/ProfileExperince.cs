using System;
using UnityEngine;

[System.Serializable]
public class ProfileExperince
{
    public int Level = 1;

    public float Experince;
    public float NextLevelExperince;

    [SerializeField]
    private int ExperinceJump;

    public bool addExperince(float exp)
    {
        Experince += exp;
        return isLevelUp();
    }

    private bool isLevelUp()
    {
        if (Experince >= NextLevelExperince)
        {
            Experince = 0;
            NextLevelExperince = NextLevelExperince * ExperinceJump;
            Level++;
            return true;
        }
        else return false;
    }
    
    public void Io_Initialize(int Experince, int Level)
    {
        this.Experince = Experince;
        this.Level = Level;

        for(int i= 1; i< Level; i++)
        {
            NextLevelExperince = NextLevelExperince * ExperinceJump;
        }
    }
}

