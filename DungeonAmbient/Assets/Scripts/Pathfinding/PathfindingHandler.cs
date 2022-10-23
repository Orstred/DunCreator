using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public struct PathRequest
{
    public IPathfindingAgent Agent;
    public GroundBlock startingBlock;
    public GroundBlock destinationBlock;
}
public class PathfindingHandler : MonoBehaviour
{
    #region Singleton
    public static PathfindingHandler instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }
    #endregion

    public MainGrid grid;
    public List<PathRequest> requestList;

    public static float BASEWEIGHT = 100f;


    private void Update()
    {
        if (requestList.Count > 0)
        {
            FufillRequest(requestList[0]);
        }
    }

    public async void FufillRequest(PathRequest request)
    {
        //Temporary variables
        List<GroundBlock> blocks = new List<GroundBlock>();
        GroundBlock currentblock = request.startingBlock;

        //Calculate path
        while(currentblock != request.destinationBlock)
        {
            blocks.Add(currentblock);

            foreach(GroundBlock block in currentblock.Neighhbours)
            {
                float currentBlocksDistanceFromGoal = Vector3.Distance(currentblock.transform.position, request.destinationBlock.transform.position);

                if (Vector3.Distance(block.transform.position, request.destinationBlock.transform.position) + BASEWEIGHT  < currentBlocksDistanceFromGoal)
                {
                    currentblock = block;
                }
            }
        }

        //add the target block at the end of path
        blocks.Add(request.destinationBlock);

        //Ansewr Request
        request.Agent.getResponse(blocks);

        //Remove Request
        requestList.Remove(request);

        await Task.Yield();
    }

    public void getNewRequest(PathRequest request)
    {
        //Removes any previous request sent by the same agent
        foreach(PathRequest r in requestList)
        {
            if(r.Agent == request.Agent)
            {
               requestList.Remove(r);
            }
        }

        requestList.Add(request);
    }

 
}
