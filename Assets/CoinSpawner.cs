using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinsPerBatch = 5;

    // The 3 coin types: the same index in both arrays is one coin type
    public int[] coinValues = { 50, 20, 10 };
    public Color[] coinColors = { new Color(1f, 0.5f, 0f), Color.green, Color.blue };

    // Coins spawn at a random position between these two corners
    public Vector2 minPosition = new Vector2(-50, -50);
    public Vector2 maxPosition = new Vector2(50, 50);

    private int coinsLeft;

    void Start()
    {
        SpawnBatch();
    }

    public void CoinCollected()
    {
        coinsLeft--;
        if (coinsLeft == 0)
        {
            SpawnBatch();
        }
    }

    private void SpawnBatch()
    {
        for (int i = 0; i < coinsPerBatch; i++)
        {
            int type = Random.Range(0, coinValues.Length);
            float x = Random.Range(minPosition.x, maxPosition.x);
            float y = Random.Range(minPosition.y, maxPosition.y);

            GameObject coin = Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
            coin.GetComponent<SpriteRenderer>().color = coinColors[type];
            coin.GetComponent<CoinScript>().value = coinValues[type];
        }

        coinsLeft = coinsPerBatch;
    }
}
