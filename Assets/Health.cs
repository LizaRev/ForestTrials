using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Параметри здоров'я")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Елементи інтерфейсу")]
    public Slider healthSlider; 

    void Start()
    {
        currentHealth = maxHealth;
        
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        
        // Обмежуємо здоров'я від 0 до максимуму
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI(); 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
        // Логіку з текстом видалено, щоб відсотки не з'являлися
    }

    void Die()
    {
        Debug.Log(gameObject.name + " загинув!");

        // Якщо це Гравець — перезавантажуємо рівень
        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Якщо це Ворог (Гоблін) — просто видаляємо його
        else 
        {
            Destroy(gameObject);
        }
    }
}