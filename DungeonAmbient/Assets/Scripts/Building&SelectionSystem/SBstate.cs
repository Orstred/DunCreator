using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SBstate
{
    protected SBManager MachineManager;

    public SBstate(SBManager machinemanager)
    {
      MachineManager = machinemanager;
    }

    public virtual void LeftClick() { }
 
    public virtual void RightClick() { }

}
