using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Initialize_Time_Behavior : I_Observer_Behavior
{

    public void update(object arg)
    {
        if (arg is Building == false) return;
        Building Observer = (Building)arg;
        if (Observer.ResourceProduction == null) return;

        Observer.InitializeProduction();
    }
}

