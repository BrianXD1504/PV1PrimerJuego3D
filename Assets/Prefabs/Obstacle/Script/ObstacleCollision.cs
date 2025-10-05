using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisi�n con: " + collision.collider.name);

        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}