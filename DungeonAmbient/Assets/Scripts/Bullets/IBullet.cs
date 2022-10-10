using UnityEngine;

public interface IBullet
{
    public void MoveForward();

    public void onHitTarget(GameObject collision);
}
