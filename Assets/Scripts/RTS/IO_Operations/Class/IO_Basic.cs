using System;
using System.Collections.Generic;
using UnityEngine;

public static class IO_Basic
{
    public static void SaveAll()
    {
        PlayerPrefs.Save();
    }

    public static void Save(String Name, String Data)
    {
        PlayerPrefs.SetString(Name, Data);
    }

    public static void Save(String Name, int Data)
    {
        PlayerPrefs.SetInt(Name, Data);
    }

    public static void Save(String Name, float Data)
    {
        PlayerPrefs.SetFloat(Name, Data);
    }

    public static String Load(String Name)
    {
        if (isExist(Name) == false) return null;
        return PlayerPrefs.GetString(Name);
    }

    public static void Delete(String Name)
    {
        PlayerPrefs.DeleteKey(Name);
    }

    private static bool isExist(String Name)
    {
        if (PlayerPrefs.HasKey(Name)) return true;
        else return false;
    }
}

