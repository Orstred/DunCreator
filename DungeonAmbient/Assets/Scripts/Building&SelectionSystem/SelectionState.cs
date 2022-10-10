using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionState : SBstate
{
    public SelectionState(SBManager MachineManager) : base(MachineManager) 
    {
    
    }


    public override void RightClick()
    {
       Deselect();
    }
    public override void LeftClick()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            IselectableBuilding Selected = hit.transform.GetComponent<IselectableBuilding>();

            if (Selected != null) 
            { Select(selectable: Selected); }
        }
    }


    public void Select(IselectableBuilding selectable)
    {
        if(MachineManager.currentSelection != null)  {Deselect(); }

        MachineManager.currentSelection = selectable;

        selectable.OnSelect();
    }   
    public void Deselect()
    {
        if (MachineManager.currentSelection != null)
        {
            MachineManager.currentSelection.OnDeselect();

            MachineManager.currentSelection = null;
        }
    }
}
