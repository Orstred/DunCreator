using UnityEngine;

public class GroundBlock : MonoBehaviour, IselectableBuilding
{

    // Grid system
    protected GroundBlock[] Neighhbours = new GroundBlock[4];

    public GroundBlock UpperNeighbour;
    public GroundBlock LowerNeighbour;
    public GroundBlock LeftNeighbour; 
    public GroundBlock RightNeighbour;

    public void setNeighbours()
    {
        Neighhbours = new GroundBlock[4];

        Neighhbours[0] = UpperNeighbour;
        Neighhbours[1] = LowerNeighbour;
        Neighhbours[2] = LeftNeighbour;
        Neighhbours[3] = RightNeighbour;
    }
    public GroundBlock[] getNeighbours()
    {
        return Neighhbours;
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
    public void OnBuild(Vector3 pos)
    {

    }
}
