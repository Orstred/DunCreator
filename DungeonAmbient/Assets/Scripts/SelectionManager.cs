using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    #region Singleton
    public static SelectionManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    #endregion



    public RaycastHit CastRayFromMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        return hit;
    }
}
