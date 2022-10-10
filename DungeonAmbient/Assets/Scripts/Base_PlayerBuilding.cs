
using UnityEngine;

public abstract class Base_PlayerBuilding : MonoBehaviour, IselectableBuilding
{
    public void OnSelect()
    {
        return;
    }
    public void OnDeselect()
    {
        return; 
    }
    public virtual void OnBuild(Vector3 pos)
    {
        Instantiate(gameObject, pos, Quaternion.identity);
    }
}
