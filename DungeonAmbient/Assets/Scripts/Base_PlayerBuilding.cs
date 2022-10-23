
using UnityEngine;

public abstract class Base_PlayerBuilding : MonoBehaviour, IselectableBuilding
{

    public GroundBlock lot;

    public void OnSelect()
    {
        return;
    }
    public void OnDeselect()
    {
        return; 
    }
    public virtual void OnBuild(Vector3 pos, GroundBlock emptylot)
    {
        Instantiate(gameObject, pos, Quaternion.identity);
        lot = emptylot;
    }
}
