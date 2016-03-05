using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicUpgrade : MonoBehaviour
{
    public int UpgradeLevel;
    public int MaxLevel;
    public float Value;
    public float UpgradeValueJump;

    protected BasicProfil Profil;
    protected UpgradeSystem _UpgradeSystem;

    public void Initialize(UpgradeSystem _UpgradeSystem, BasicProfil _Profil)
    {
        this._UpgradeSystem = _UpgradeSystem;
        Profil = _Profil;
    }

    public void UpdateAllUpgradess()
    {
        _UpgradeSystem.UpdateUpgrades(_UpgradeSystem.Upgrades);
        _UpgradeSystem.UpdateUpgrades(_UpgradeSystem.PercentUpgrades);
    }

    public bool IsMaxLevel()
    {
        if (UpgradeLevel < MaxLevel) return true;
        else return false;
    }

    public void UpgradeUP()
    {
        UpgradeLevel++;
        Value += UpgradeValueJump;

        _UpgradeSystem.UpdateUpgrades(_UpgradeSystem.Upgrades);
        _UpgradeSystem.UpdateUpgrades(_UpgradeSystem.PercentUpgrades);
    }

    public abstract void UpdateStatus();
}
