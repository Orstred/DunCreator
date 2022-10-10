using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Base_Enemy : MonoBehaviour, IHealth, IselectableBuilding
{
    [SerializeField] private int Health = 10;
    [SerializeField] private int MaxHealth = 10;

    private void Start()
    {
        Health = MaxHealth;
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

    //Selectable obj interface implementation
    public void OnSelect()
    {
        return;
    }
    public void OnDeselect()
    {
        return;
    }
    public void OnBuild(Vector3 pos)
    {
        return;
    }
}
