using UnityEngine;


public interface IMovementStrategy
{
   
    void Move(Transform target, Rigidbody rb, float velocidadMax, float aceleracionNormal, float aceleracionExtra, float desaceleracion);
}