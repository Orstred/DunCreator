using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainGrid : MonoBehaviour
{

    [SerializeField] private Transform[] grid;

    [Min(1)]
    [SerializeField] private int Width;


    [Button]
    public void updateGrid()
    {
        grid = GetComponentsInChildren<Transform>();

        turnEllementsIntoGridBlocks();

        organizeGrid();

        setGridBlocksNeighbours();
    }


    public void turnEllementsIntoGridBlocks()
    {
        foreach (Transform t in grid)
        {
            t.tag = "Ground";

            if (t.GetComponent<GroundBlock>() == null)
            {
               t.gameObject.AddComponent<GroundBlock>();
            }
        }
    }

    public void setGridBlocksNeighbours()
    {
        GroundBlock[] blocks = GetComponentsInChildren<GroundBlock>();


        foreach (GroundBlock block in blocks)
        {

            block.UpperNeighbour = null;
            block.LowerNeighbour = null;
            block.LeftNeighbour = null;
            block.RightNeighbour = null;

            foreach (GroundBlock t in blocks)
            {
             if (t.transform.localPosition == block.transform.localPosition + Vector3.forward)
                {
                    block.UpperNeighbour = t;
                }
             if (t.transform.localPosition == block.transform.localPosition + Vector3.back)
                {
                    block.LowerNeighbour = t;
                }
             if (t.transform.localPosition == block.transform.localPosition + Vector3.right)
                {
                    block.RightNeighbour = t;
                }
             if (t.transform.localPosition == block.transform.localPosition + Vector3.left)
                {
                    block.LeftNeighbour = t;
                }
            }

            block.setNeighbours();
        }

   
    }
    
    public void organizeGrid(int startofrow = 1, int row = 0)
    {
        for (int i = 0; i < Width; i++)
        {
            if (i + startofrow > grid.Length - 1)
            {
                return;
            }

            Transform currenttile = grid[i + startofrow];

            currenttile.localPosition = new Vector3(i, 0, row);
        }

        organizeGrid(startofrow: startofrow + Width, row: row + 1);
    }
   
    public GroundBlock[] getGridEllements()
    {
        return GetComponentsInChildren<GroundBlock>();
    }
}
