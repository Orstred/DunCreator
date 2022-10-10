using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHUD : MonoBehaviour
{
    public SBManager SBmanager;
 
    public void StartBuilding(Base_PlayerBuilding building)
    {
        if(SBmanager.currentSelection != null)
        SBmanager.currentSelection.OnDeselect();

        SBmanager.SetState(new BuildingState(SBmanager));

        SBmanager.currentSelection = building;
    }


}
