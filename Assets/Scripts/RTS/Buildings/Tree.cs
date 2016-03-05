using UnityEngine;
using System.Collections;

public class Tree : Building
{
    private int TreeCapacity;

    void Awake()
    {
        TreeCapacity = ((TreeType)DefaultGrup).TreeCapacity;

        subject.Add(this);
        if (DefaultGrup.name != "Tree")
        {
            Debug.LogError("System Rozjebany!");
            return;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public int subCapacty(int Value)
    {
        TreeCapacity -= Value;
        return TreeCapacity;
    }

}
