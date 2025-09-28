using UnityEngine;

public class MovimientoLateral : IMovementStrategy
{
    public void Move(Transform target, float speed)
    {
        float direccion = Input.GetAxis("Horizontal");
        target.Translate(direccion * speed * Time.deltaTime, 0, 0);
    }
}