using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector3 fuerzaPorAplicar = new Vector3(0, 0, 11f);
    [SerializeField] private float intervaloTiempo = 2f;
    [SerializeField] private float velocidadLateral = 3f;

    [SerializeField] private float velocidadMax = 15f;
    [SerializeField] private float aceleracionNormal = 20f;
    [SerializeField] private float aceleracionExtra = 40f;
    [SerializeField] private float desaceleracion = 30f;

    private float tiempoDesdeUltimaFuerza = 0f;
    private IMovementStrategy strategy;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetStrategy(new MovimientoAcelerado()); 
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        strategy?.Move(transform, rb, velocidadMax, aceleracionNormal, aceleracionExtra, desaceleracion);

        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            rb.AddForce(fuerzaPorAplicar, ForceMode.Impulse);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }

   
    public void SetStrategy(IMovementStrategy nueva)
    {
        strategy = nueva;
    }
}