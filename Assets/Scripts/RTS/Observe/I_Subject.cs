using System;
using System.Collections.Generic;

public interface I_Subject
{
    void Add(I_Observer ob);
    void Remove(I_Observer ob);
    void AdviseAll(I_Observer_Behavior behavior, object arg);
    void AdviseAll(I_Observer_Behavior behavior);
}

