using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionTool : MonoBehaviour
{

    [SerializeField] private DungeonObject CurrentTool;

    private SelectionManager selector;


    private void Start()
    {
        selector = SelectionManager.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
         BuildAtHitPoint(raycasthit: selector.CastRayFromMouse());  
        }
    }


    public void SelectTool(DungeonObject dungeonobject)
    {
        CurrentTool = dungeonobject;
    }

    public void BuildAtHitPoint(RaycastHit raycasthit)
    {
        if (raycasthit.transform != null)
        {
            bool isground = (raycasthit.transform.tag == "Ground");

            if (isground)
            {
                Vector3 spawnpoint = new Vector3(raycasthit.point.x, 0, raycasthit.point.z);

                Instantiate(CurrentTool, spawnpoint, Quaternion.identity);
            }
        }
    }

    public void Destroy()
    {

    }
}
