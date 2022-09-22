using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MakeGrid : MonoBehaviour
{

    [SerializeField] private Transform[] grid;
    [SerializeField] private int Width;


    [Button]
    public void updateGrid()
    {
        if (Width <= 0) { Width = 1; }

        getGridEllements();

        TurnEllementsIntoGridBlocks();

        makeGrid();

        setGridBlocksNeighbours();
    }

    public void getGridEllements()
    {
      grid = GetComponentsInChildren<Transform>();
    }

    public void TurnEllementsIntoGridBlocks()
    {
        foreach (Transform t in grid)
        {
            t.tag = "Ground";

            if (t.GetComponent<GridBlock>() == null)
            {
                    t.gameObject.AddComponent<GridBlock>();
            }
        }
    }

    public void setGridBlocksNeighbours()
    {
        GridBlock[] blocks = GetComponentsInChildren<GridBlock>();

        int i = 0;

        foreach (GridBlock block in blocks)
        {
            foreach (GridBlock t in blocks)
            {
             if (t.transform.position == block.transform.position + Vector3.forward)
                {
                    block.UpperNeighbour = t;
                }
             if (t.transform.position == block.transform.position + Vector3.back)
                {
                    block.LowerNeighbour = t;
                }
             if (t.transform.position == block.transform.position + Vector3.right)
                {
                    block.RightNeighbour = t;
                }
             if (t.transform.position == block.transform.position + Vector3.left)
                {
                    block.LeftNeighbour = t;
                }
            }

            //block.blockAbove = getUpperNeghbour(i);
            //block.blockBelow = getLowerNeghbour(i);
            //block.blockLeft  = getLeftNeighbour(i);
            //block.blockRight = getRightNeighbour(i);
            //i++;
        }


        GridBlock getUpperNeghbour(int currentblock = 0) 
        {
            if (currentblock + Width > grid.Length - 1)
                return null;

            return grid[currentblock + Width].GetComponent<GridBlock>();
        }
        GridBlock getLowerNeghbour(int currentblock = 0) 
        {
            if (currentblock - Width < 0 || grid[currentblock - Width] == null)
                return null;

            return grid[currentblock - Width].GetComponent<GridBlock>();
        }
        GridBlock getLeftNeighbour(int currentblock = 0) 
        {
            return null;
        }
        GridBlock getRightNeighbour(int currentblock = 0) 
        {
            return null;
        }

        GridBlock findOnGridByPos(Vector3 pos)
        {
            foreach (GridBlock block in blocks)
            {
                if(block.transform.position == pos)
                    return block;
            }
            return null;
        }
    }
    
    public void makeGrid(int startofrow = 1, int row = 0)
    {
        for (int i = 0; i < Width; i++)
        {
            if (i + startofrow > grid.Length - 1) return;

            Transform currenttile = grid[i + startofrow];

            currenttile.position = new Vector3(i, 0, row);
        }

        makeGrid(startofrow: startofrow + Width, row: row + 1);
    }
   
}
