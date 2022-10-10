using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPathfindingAgent
{

    public void sendRequest(GroundBlock start, GroundBlock destination);
    public void getResponse();

}
