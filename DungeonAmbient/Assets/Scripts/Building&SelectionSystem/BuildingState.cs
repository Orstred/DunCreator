using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : SBstate
{

    public BuildingState(SBManager MachineManager) : base(MachineManager) 
    {
      
    }


    public override void LeftClick()
    {
        Build();
    }
    public override void RightClick()
    {
       CancellBuilding();
    }


    public void Build()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GroundBlock emptylot = hit.transform.GetComponent<GroundBlock>();

            if (emptylot != null)
            {
          
                Vector3 emptylotpos = hit.transform.position + Vector3.up;

                if (!isThereSomethingAbove(emptylotpos))
                {
                    MachineManager.currentSelection.OnBuild(pos: emptylotpos, emptylot);
                }
            }
            
        }

        //local methods
        bool isThereSomethingAbove(Vector3 pos)
        {
           return Physics.CheckSphere(pos + (Vector3.up / 5), .1f);
        }
    }
    public void CancellBuilding()
    {
        MachineManager.currentSelection.OnDeselect();

        MachineManager.currentSelection = null;

        MachineManager.SetState(new SelectionState(MachineManager));
    }
}
