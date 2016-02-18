using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeSystem : MonoBehaviour{

    public List<BasicUpgrade> Upgrades;
    public List<BasicUpgrade> PercentUpgrades;

    private BuildingStatistic _BuildingStatistic;


	// Use this for initialization
	void Awake () {
        SortPercentUpgrades();
	}
	
    public BuildingStatistic getBuildingStatistic()
    {
        return _BuildingStatistic;
    }

    public void UpdateUpgrades(List<BasicUpgrade> list)
    {
        IEnumerator<BasicUpgrade> iter = Upgrades.GetEnumerator();
        List<BasicUpgrade> tmpUpgrades = new List<BasicUpgrade>();
        _BuildingStatistic.ResetAllStatistic();

        while (iter.MoveNext())
        {
            BasicUpgrade _BasicUpgrade = iter.Current;
            _BasicUpgrade.UpdateStatus();
        }
    }

    private void SortPercentUpgrades()
    {
        if (PercentUpgrades.ToArray().Length < 2) return; 

        int i = 0;
        int j = 1;
        int END = PercentUpgrades.ToArray().Length - 1;

        while(END >= 0)
        {
            BasicUpgrade tmpUpgrade = (BasicUpgrade)PercentUpgrades.ToArray().GetValue(i);
            BasicUpgrade tmpUpgrade2 = (BasicUpgrade)PercentUpgrades.ToArray().GetValue(j);

            if(tmpUpgrade.Value > tmpUpgrade2.Value)
            {
                PercentUpgrades[i] = tmpUpgrade2;
                PercentUpgrades[j] = tmpUpgrade;
            }

            i++;
            j++;

            if(j == PercentUpgrades.ToArray().Length - 1)
            {
                i = 0;
                j = 1;
                END--;
            }
        }
    }

    private List<BasicUpgrade> CopyUpgrades(List<BasicUpgrade> _Upgrades)
    {
        IEnumerator<BasicUpgrade> iter = _Upgrades.GetEnumerator();
        List<BasicUpgrade> tmpUpgrades = new List<BasicUpgrade>();

        while (iter.MoveNext())
        {
            BasicUpgrade _BasicUpgrade = iter.Current;

            _BasicUpgrade = Instantiate<BasicUpgrade>(_BasicUpgrade);
            _BasicUpgrade.Initialize(this, _BuildingStatistic);
            _BasicUpgrade.transform.parent = this.gameObject.transform;
            tmpUpgrades.Add(_BasicUpgrade);
        }
       return tmpUpgrades;
        
    }

    public void setBuildStatistic(BuildingStatistic bStatistic)
    {
        _BuildingStatistic = bStatistic;

        Upgrades = CopyUpgrades(Upgrades);
        PercentUpgrades = CopyUpgrades(PercentUpgrades);

        UpdateUpgrades(Upgrades);
    }

    public void ReloadUpdates()
    {
        SortPercentUpgrades();
        
        Upgrades = CopyUpgrades(Upgrades);
        PercentUpgrades = CopyUpgrades(PercentUpgrades);

        UpdateUpgrades(Upgrades);
    }
}
