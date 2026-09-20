using UnityEngine;

public class Collector : MonoBehaviour
{
    private const string EnemyTag = "Enemy";
    private const string PlayerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag) || collision.CompareTag(PlayerTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
