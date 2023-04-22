using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
            other.transform.position = spawnPoint.transform.position;
        }
    }
}
