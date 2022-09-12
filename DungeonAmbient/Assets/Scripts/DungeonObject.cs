using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DungeonObject : MonoBehaviour
{

    private void Start()
    {
        transform.position = RoundedVector(transform.position);
    }

    private Vector3 RoundedVector(Vector3 vector)
    {
        float Xaxis = (float)Math.Round(vector.x);
        float Yaxis = (float)Math.Round(vector.y);
        float Zaxis = (float)Math.Round(vector.z);

        return new Vector3(Xaxis, Yaxis, Zaxis);
    }
}
