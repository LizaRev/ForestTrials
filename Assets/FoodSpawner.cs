using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [Header("Settings")]
    public Sprite[] foodSprites;
    public float spawnInterval = 0.5f;
    public float xMin = -8f;
    public float xMax = 9f;
    public float ySpawn = 6f;

    [Header("Physics Settings")]
    public float gravityScale = 1.5f;
    public float foodScale = 2f;

    void Start()
    {
        InvokeRepeating("SpawnFood", 1f, spawnInterval);
    }

    void SpawnFood()
    {
        if (foodSprites.Length == 0) return;

        int count = Random.Range(1, 8); 

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, foodSprites.Length);
            GameObject newFood = new GameObject("Food");

            float xPos = Random.Range(xMin, xMax);
            float randomYOffset = Random.Range(0f, 5f); 
            
            newFood.transform.position = new Vector3(xPos, ySpawn + randomYOffset, 0);
            newFood.transform.localScale = Vector3.one * foodScale;

            SpriteRenderer sr = newFood.AddComponent<SpriteRenderer>();
            sr.sprite = foodSprites[index];
            sr.sortingOrder = 5;

            Rigidbody2D rb = newFood.AddComponent<Rigidbody2D>();
            rb.gravityScale = gravityScale;

            PolygonCollider2D collider = newFood.AddComponent<PolygonCollider2D>();
            collider.isTrigger = true;

            newFood.AddComponent<FoodPickup>();

            Destroy(newFood, 6f);
        }
    }
}