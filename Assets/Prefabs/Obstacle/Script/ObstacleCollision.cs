using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión con: " + collision.collider.name);

        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}