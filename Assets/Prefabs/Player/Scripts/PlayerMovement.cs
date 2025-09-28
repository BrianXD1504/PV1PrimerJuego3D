using UnityEngine;
/// <summary>
/// Permite el comportamiento de movimiento del jugador.
/// </summary>


public class PlayerMovement : MonoBehaviour
{
    #region Atributos
    /// <summary> 
    /// Fuerza de movimiento del jugador.
    /// <summary>
    private Vector3 fuerzaPorAplicar;
    /// <summary> 
    /// Representa el tiempo que ha trancurrido desde la ultima vez que se aplico una fuerza al jugador.
    /// <summary>
    private float tiempoDesdeUltimaFuerza;
    /// <summary> 
    /// Indica cada cuanto tiempo se aplica una fuerza al jugador.
    /// <summary>
    private float intervaloTiempo;
    /// <summary>
    /// Indica la velociudad aplicada en el movimiento lateral del jugador.
    /// </summary>
    private float velocidadLateral;
    /// <summary>
    /// Representa la estrategia de movimiento lateral del jugador.
    /// </summary>
    private IMovementStrategy strategy;

    #endregion

    #region Ciclo de vida del script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 11f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
        velocidadLateral = 3f;
        SetStrategy(new MovimientoAcelerado());

    }


    private void Update()
    {
        strategy.Move(transform, velocidadLateral);
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }

    }


    #endregion

    #region Lógica del script
    public void SetStrategy(IMovementStrategy strategy)
    {
        this.strategy = strategy;
    }
    #endregion
}