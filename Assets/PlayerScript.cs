using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    public int targetScore = 1000;
    public CoinSpawner coinSpawner;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get WASD input every frame
        float h = Keyboard.current.dKey.value - Keyboard.current.aKey.value;
        float v = Keyboard.current.wKey.value - Keyboard.current.sKey.value;
        moveDirection = new Vector2(h, v).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement in FixedUpdate
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("you lose");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Coin"))
        {
            CoinScript coin = other.GetComponent<CoinScript>();
            score += coin.value;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);

            if (score >= targetScore)
            {
                Debug.Log("you won");
                Destroy(gameObject);
                return;
            }

            coinSpawner.CoinCollected();
        }
    }
}
