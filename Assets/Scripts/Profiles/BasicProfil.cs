﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(UpgradeManager))]
public abstract class BasicProfil : MonoBehaviour {
    
    [System.NonSerialized]
    public I_Resource[] Resources;
    public I_Resource[] SpecialResources;
    public Tools Tool;

    public ProfileExperince exp;

    public ClickerStatistic _ClickerStatistic;
    public AutoStatistic _AutoStatistic;

    private ClickerStatistic OryginalClickerStatistic;
    private AutoStatistic OryginalAutoStatistic;

    private UpgradeManager Upgrades;

	// Use this for initialization
	void Start () {
        Upgrades = this.gameObject.GetComponent<UpgradeManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void addClickUpgrade(BasicUpgrade Upgrade)
    {
        Upgrades.ClickerUpgrades.Upgrades.Add(Upgrade);
        Upgrades.ClickerUpgrades.ReloadUpdates();
    }

    public void addAutoUpgrade(BasicUpgrade Upgrade)
    {
        Upgrades.AutoUpgrades.Upgrades.Add(Upgrade);
        Upgrades.AutoUpgrades.ReloadUpdates();
    }

    public I_Resource[] getResources()
    {
        return this.Resources;
    }

    public int getRandomHitValue()
    {
        return Random.Range(_ClickerStatistic.MinHit, _ClickerStatistic.MaxHit);
    }

    public void InitializeOryginalStatistic()
    {
        OryginalClickerStatistic = ClickerStatistic.Copy(_ClickerStatistic);
    }

}
