using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Round
{
    public GameObject[] enemies;
}
public class EnemySpawner : MonoBehaviour
{

    public GroundBlock currentBlock;
    public GroundBlock target;

    public Base_Enemy spawnable;

    public float spawnRate = 10f;

    public float TimeBetweenRounds = 60f;

    public Round[] round;


    private float rate;


    private void Start()
    {
        currentBlock.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    private void Update()
    {
        rate -= Time.deltaTime; 

        if(rate <= 0)
        {
            Base_Enemy en = Instantiate(spawnable, currentBlock.transform.position, currentBlock.transform.rotation);
            
            en.sendRequest(startingblock: currentBlock, destinationblock: target);

            rate = spawnRate;
        }
    }
}
