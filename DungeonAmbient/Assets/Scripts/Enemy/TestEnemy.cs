using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TestEnemy : Base_Enemy
{
    public int currentBlockinPath = -1;

    private void Update()
    {
        if(currentPath.Count > 0)
        {
            move(currentPath[currentBlockinPath]);

            if(Vector3.Distance(transform.position, currentPath[currentBlockinPath].transform.position + Vector3.up) < 0.15f)
            {
                if(currentPath.Count - 1 > currentBlockinPath)
                currentBlockinPath++;
            }
        }
    }
}
