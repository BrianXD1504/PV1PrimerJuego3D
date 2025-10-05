using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Interfaz para comandos de entrada.
/// </summary>
public interface ICommand
{
    float Ejecutar();
}


public class Comando : ICommand
{
    private Func<float> accion;

    public Comando(Func<float> accion)
    {
        this.accion = accion;
    }

    public float Ejecutar() => accion();
}

/// <summary>
/// usar tecla A izquiereda y S para de derecha
/// </summary>
public static class ComandosMovimiento
{
    public static List<ICommand> Direccion() => new List<ICommand>
    {
        new Comando(() => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ? -1f : 0f),
        new Comando(() => Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.RightArrow) ? 1f : 0f)
    };

    public static ICommand Boost() =>
        new Comando(() => Input.GetKey(KeyCode.Space) ? 1f : 0f);
}