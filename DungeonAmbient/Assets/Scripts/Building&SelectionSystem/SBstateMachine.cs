using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBstateMachine : MonoBehaviour
{

    protected SBstate State;

    public void SetState(SBstate state)
    {
        State = state;
     
        Debug.Log("Current SBstate is: " + state.ToString());
    }



}
