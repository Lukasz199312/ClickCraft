using System;
using UnityEngine;
using System.Collections.Generic;

public interface I_Observer
{
    I_Observer_Behavior ChangeBehavior(I_Subject subject, I_Observer_Behavior Behavior);
    GameObject gameobject();
}
