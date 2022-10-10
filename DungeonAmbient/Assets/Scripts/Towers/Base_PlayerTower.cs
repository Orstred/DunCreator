using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_PlayerTower : Base_PlayerBuilding
{

    [SerializeField] private Transform[] shooters;

    [SerializeField] private GameObject Bullet;

    [HideInInspector] public Base_Enemy currentTarget;

    public virtual void Shoot()
    {
        foreach (Transform t in shooters)
        {
            if (t != null)
            {
               Instantiate(Bullet, t.position, t.rotation);
            }
        }
    }

}
