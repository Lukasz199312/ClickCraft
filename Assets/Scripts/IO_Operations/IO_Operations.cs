using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IO_Operations : MonoBehaviour , I_Subject{

    private List<I_Observer> Observers = new List<I_Observer>();

	// Use this for initialization
	void Start () {

        IEnumerator<I_Observer> iter = Observers.GetEnumerator();
        while(iter.MoveNext())
        {
            I_Observer ob = iter.Current;
            IO_Format format = ob.gameobject().GetComponent<IO_Format>();
 
            ob.ChangeBehavior(this, new IO_LoadBehavior()).update(format);

        }

	}
	
    void OnApplicationQuit()
    {
        IEnumerator<I_Observer> iter = Observers.GetEnumerator();

        while (iter.MoveNext())
        {
            I_Observer ob = iter.Current;
            IO_Format format = ob.gameobject().GetComponent<IO_Format>();

            ob.ChangeBehavior(this, new IO_SaveBehavior()).update(format);
            IO_Basic.SaveAll();
        }
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
