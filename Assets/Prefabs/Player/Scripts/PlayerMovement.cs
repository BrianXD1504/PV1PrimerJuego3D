using UnityEngine;


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

    #endregion



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 5f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
        velocidadLateral = 2f;

    }


    private void Update()
    {
        float direccion = Input.GetAxis("Horizontal");
        transform.Translate(direccion * velocidadLateral * Time.deltaTime, 0, 0);
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
}
