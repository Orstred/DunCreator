using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour, IBullet
{

    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private int Damage = 10;
    [SerializeField] private float StayTime = 5f;

    private float rate = 5f;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;

        rate = StayTime;
    }

    private void Update()
    {
        rate -= Time.deltaTime;

        if (rate <= 0)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
       MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerBuilding"))
        {
            return;
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("IgnoreRaycast"))
        {
            return;
        }
        onHitTarget(other.gameObject);
    }

    public void MoveForward()
    {
       _transform.position += _transform.forward * Time.deltaTime * Speed;
    }

    public void onHitTarget(GameObject collision)
    {
        if(collision.GetComponent<Base_Enemy>() != null)
        {
            collision.GetComponent<IHealth>().UpdateHealth(-Damage);
            Destroy(gameObject);
        }
    }
}
