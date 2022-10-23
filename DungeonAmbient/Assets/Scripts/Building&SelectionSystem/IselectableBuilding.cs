using UnityEngine;


public interface IselectableBuilding
{
    public void OnSelect();
    public void OnDeselect();
    public void OnBuild(Vector3 pos, GroundBlock block);
}
