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
        Observers.Remove(ob);
    }

    public virtual void AdviseAll(I_Observer_Behavior Behavior)
    {
        IEnumerator<I_Observer> iter = Observers.GetEnumerator();

        while( iter.MoveNext() )
        {
            I_Observer observer = iter.Current;
            observer.ChangeBehavior(this, Behavior).update(observer);
        }
    }

    public virtual void AdviseAll(I_Observer_Behavior Behavior, object arg)
    {
        IEnumerator<I_Observer> iter = Observers.GetEnumerator();

        while (iter.MoveNext())
        {
            I_Observer observer = iter.Current;
            observer.ChangeBehavior(this, Behavior).update(arg);
        }
    }
}
