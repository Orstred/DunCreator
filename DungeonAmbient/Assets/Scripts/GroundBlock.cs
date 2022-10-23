using UnityEngine;
using System.Collections.Generic;

public class GroundBlock : MonoBehaviour, IselectableBuilding
{

    // Grid system
    public GroundBlock[] Neighhbours = new GroundBlock[4];

    public GroundBlock UpperNeighbour;
    public GroundBlock LowerNeighbour;
    public GroundBlock LeftNeighbour; 
    public GroundBlock RightNeighbour;

    public void setNeighbours()
    {
        List<GroundBlock> neighbours = new List<GroundBlock>();

        if (UpperNeighbour != null)
            neighbours.Add(UpperNeighbour);
        if (LowerNeighbour != null)
            neighbours.Add(LowerNeighbour);
        if (LeftNeighbour != null)
            neighbours.Add(LeftNeighbour);
        if (RightNeighbour != null)
            neighbours.Add(RightNeighbour);

        Neighhbours = neighbours.ToArray();
    }



    //Pathfinding
    public float Weight;


    //Iselectable Interface Implementation
    public void OnSelect()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
    public void OnDeselect()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    public void OnBuild(Vector3 pos, GroundBlock emptylot) { }

}
