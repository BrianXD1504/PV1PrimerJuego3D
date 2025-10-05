using UnityEngine;
using System.Collections.Generic;

public class MovimientoLateral : IMovementStrategy
{
    private List<ICommand> comandos = ComandosMovimiento.Direccion();

    public void Move(Transform target, Rigidbody rb, float velocidadMax, float aceleracionNormal, float aceleracionExtra, float desaceleracion)
    {
        float direccion = 0f;
        foreach (var comando in comandos)
        {
            direccion += comando.Ejecutar();
        }

        Vector3 movimiento = new Vector3(direccion * velocidadMax * Time.fixedDeltaTime, 0, 0);
        rb.MovePosition(rb.position + movimiento);
    }
}