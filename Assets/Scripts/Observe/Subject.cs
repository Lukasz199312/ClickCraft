using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subject : MonoBehaviour, I_Subject {

    protected List<I_Observer> Observers = new List<I_Observer>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Add(I_Observer ob)
    {
        Observers.Add(ob);
    }

    public void Remove(I_Observer ob)
    {
        throw new System.NotImplementedException();
    }

    public void AdviseAll(I_Observer ob)
    {
        throw new System.NotImplementedException();
    }
}
