using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public interface IPathfindingAgent
{
    public void sendRequest(GroundBlock start, GroundBlock destination);
    public void getResponse(List<GroundBlock> path);
}
