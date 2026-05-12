using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Food hit: " + other.gameObject.name + " | Tag: " + other.tag);

        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddFood(1);
            }
            else
            {
                Debug.LogError("GameManager не знайдено на сцені!");
            }

            Destroy(gameObject);
        }
        
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}