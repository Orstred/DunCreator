using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBManager : SBstateMachine
{
    public IselectableBuilding currentSelection;

    public string obname;

    private void Start()
    {
        SetState(new SelectionState(this));
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            State.LeftClick();
        }
        if(Input.GetMouseButton(1))
        {
            State.RightClick();
        }
    }

    private void LateUpdate()
    {
        obname = "Nothing selected";

        if(currentSelection != null)
        {
            obname = currentSelection.ToString();
        }
    }
}
