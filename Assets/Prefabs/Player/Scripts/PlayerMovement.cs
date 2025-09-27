using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    private Vector3 fuerzaPorAplicar;
    private float tiempoDesdeUltimaFuerza;
    private float intervaloTiempo;

    void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 10);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
    }

    void FixedUpdate()
    {
        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;

        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }
}