using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Subject : MonoBehaviour, I_Subject {

    public int size;
    protected List<I_Observer> Observers = new List<I_Observer>();
    protected List<I_Observer> ObserversToRemove = new List<I_Observer>();

	// Use this for initialization
	void Start () {
	    size = Observers.Count;
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
        //Observers.Remove(ob);
        ObserversToRemove.Add(ob);
    }

    public virtual void AdviseAll(I_Observer_Behavior Behavior)
    {
        RemoveListed();
        IEnumerator<I_Observer> iter = Observers.GetEnumerator();

        while( iter.MoveNext() )
        {
            I_Observer observer = iter.Current;
            observer.ChangeBehavior(this, Behavior).update(observer);

        }
    }

    public virtual void AdviseAll(I_Observer_Behavior Behavior, object arg)
    {
        RemoveListed();
        IEnumerator<I_Observer> iter = Observers.GetEnumerator();

        while (iter.MoveNext())
        {
            I_Observer observer = iter.Current;
            observer.ChangeBehavior(this, Behavior).update(arg);
        }
    }

    private void RemoveListed()
    {
        foreach( I_Observer ob in ObserversToRemove)
        {
            Observers.Remove(ob);
        }
    }
}
