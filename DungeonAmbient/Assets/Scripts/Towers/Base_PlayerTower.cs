using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_PlayerTower : Base_PlayerBuilding
{

    [SerializeField] private Transform[] shooters;

    [SerializeField] private GameObject Bullet;

     public Base_Enemy currentTarget;

    
    public virtual void Shoot()
    {
        foreach (Transform t in shooters)
        {
            if (t != null)
            {
              GameObject bull = Instantiate(Bullet, t.position, t.rotation);
                bull.transform.parent = null;
                bull.transform.position = t.position;
                bull.transform.rotation = t.rotation;
                bull.transform.localScale = Vector3.one;
            }
        }
    }

}
