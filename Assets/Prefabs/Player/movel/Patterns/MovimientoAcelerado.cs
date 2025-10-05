using UnityEngine;
using System.Collections.Generic;

public class MovimientoAcelerado : IMovementStrategy
{
    private float velocidadActual = 0f;
    private List<ICommand> comandos = ComandosMovimiento.Direccion();
    private ICommand boost = ComandosMovimiento.Boost();

    public void Move(Transform target, Rigidbody rb, float velocidadMax, float aceleracionNormal, float aceleracionExtra, float desaceleracion)
    {
        float direccion = 0f;
        foreach (var comando in comandos)
        {
            direccion += comando.Ejecutar();
        }

        float aceleracionActual = boost.Ejecutar() > 0f ? aceleracionExtra : aceleracionNormal;

        if (direccion != 0)
        {
            velocidadActual += aceleracionActual * Time.fixedDeltaTime;
            velocidadActual = Mathf.Clamp(velocidadActual, 0f, velocidadMax);
        }
        else
        {
            velocidadActual -= desaceleracion * Time.fixedDeltaTime;
            velocidadActual = Mathf.Max(velocidadActual, 0f);
        }

        Vector3 movimiento = new Vector3(direccion * velocidadActual * Time.fixedDeltaTime, 0, 0);
        rb.MovePosition(rb.position + movimiento);
    }
}