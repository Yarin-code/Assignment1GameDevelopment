using UnityEngine;

// Attached to the Enemy. Chases the player every physics step.
public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // The player is destroyed when the game ends
        if (player == null) return;

        Vector2 direction = ((Vector2)player.transform.position - rb.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
