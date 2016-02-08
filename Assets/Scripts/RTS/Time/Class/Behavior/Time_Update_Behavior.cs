using UnityEngine;
using System.Collections;

public class Time_Update_Behavior : I_Observer_Behavior {


    public void update(object arg)
    {
        if (arg is Building == false) return;
        Building Observer = (Building)arg;
        if (Observer.ResourceProduction == null) return;

        Observer.Produce();
       // Debug.Log("Name: " + Observer.name);
    }
}
