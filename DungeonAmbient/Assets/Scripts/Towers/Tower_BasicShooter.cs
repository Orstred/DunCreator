using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower_BasicShooter : Base_PlayerTower
{

    [SerializeField] private float _radius;

    [SerializeField] private Transform _head;

    [SerializeField] private float fireRate = 1;

    private float rate;

    private void OnEnable()
    {
        GameObject _object = new GameObject("Trigger");

        _object.layer = LayerMask.NameToLayer("Ignore Raycast");
        _object.transform.parent = transform;
        _object.AddComponent<Tower_Trigger>();
        _object.transform.localPosition = Vector3.zero;


        SphereCollider _trigger = _object.AddComponent<SphereCollider>();

        _trigger.radius = _radius;
        _trigger.isTrigger = true;

    }

    private void Start()
    {
        if( _head == null)
        {
            _head = transform;
        }
        rate = fireRate;
    }

    private void LateUpdate()
    {
        if(currentTarget != null)
        {
           _head.LookAt(currentTarget.transform);

            rate -= Time.deltaTime;

            if(rate < 0)
            {
                Shoot();

                rate = fireRate;
            }
           
        }
    }

}

public class Tower_Trigger : MonoBehaviour
{
    private Base_PlayerTower parenttower;

    private void OnEnable()
    {
        parenttower = GetComponentInParent<Base_PlayerTower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Base_Enemy>() != null)
        {
            parenttower.currentTarget = other.GetComponent<Base_Enemy>();
        }
    }
}   
