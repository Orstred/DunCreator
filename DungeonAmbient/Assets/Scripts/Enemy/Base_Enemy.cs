using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Base_Enemy : MonoBehaviour, IHealth, IselectableBuilding, IPathfindingAgent
{
    [SerializeField] private int Health = 10;
    [SerializeField] private int MaxHealth = 10;
    [SerializeField] private float speed = 6f;

    private PathfindingHandler pathmanager;
    public List<GroundBlock> currentPath;



    private void Awake()
    {
        pathmanager = PathfindingHandler.instance;
        Health = MaxHealth;
    }
    

    public virtual void move(GroundBlock block)
    {
        Vector3 Targetpos = block.transform.position + Vector3.up;

        float distance = Vector3.Distance(transform.position, Targetpos);

        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * speed / distance);
    }


    //Health Interface Implementation
    public virtual void UpdateHealth(int health = 0, int maxHealth = 0)
    {
        if (!(health > 0 && this.Health >= maxHealth))
        {
            this.Health += health;
        }
        if (health < 0)
        {
            this.Health += health;
        }

        this.MaxHealth += maxHealth;

        if (health > MaxHealth)
        {
            health = MaxHealth;
        }


        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    //Selectable object interface implementation
    public void OnSelect()
    {
        return;
    }
    public void OnDeselect()
    {
        return;
    }
    public void OnBuild(Vector3 pos, GroundBlock emptylot)
    {
        return;
    }


    //Pathfinding Interface implementation
    public void sendRequest(GroundBlock startingblock, GroundBlock destinationblock)
    {
        PathRequest request = new PathRequest();

        request.Agent = this;
        request.startingBlock = startingblock;
        request.destinationBlock = destinationblock;

        pathmanager.getNewRequest(request);
    }
    public void getResponse(List<GroundBlock> path)
    {
        currentPath = path;
    }
}
