using UnityEngine;

public interface IMovementStrategy
{
    public void Move(Transform targe, float speed);
}