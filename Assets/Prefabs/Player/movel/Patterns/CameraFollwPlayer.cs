using UnityEngine;

/// <summary>
/// Camara para player  directamente con un offset cercano.
/// </summary>
public class CameraFollowPlayer : MonoBehaviour
{
    private Transform objetivo;
    private Vector3 offset = new Vector3(0, 2, -5); // para que la camara se acerque a player

   public void Start()
    {
        // Busca al player 
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            objetivo = player.transform;
        }
    }

    private void LateUpdate()
    {
        if (objetivo != null)
        {
            transform.position = objetivo.position + offset;
        }
    }
}
