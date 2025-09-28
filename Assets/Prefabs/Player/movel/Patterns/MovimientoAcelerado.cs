using UnityEngine;

// Estrategia de movimiento con aceleración horizontal
public class MovimientoAcelerado : IMovementStrategy
{
    private float velocidadActual = 0f;    
    private float aceleracion = 2f;        
    
    public void Move(Transform transform, float speed)
    {
       
        velocidadActual += Input.GetAxis("Horizontal") * aceleracion;

        velocidadActual = Mathf.Clamp(velocidadActual, -speed, speed);

        transform.Translate(velocidadActual * Time.deltaTime,0,0);
    }
}