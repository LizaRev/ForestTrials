using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Налаштування польоту")]
    public float speed = 15f;      // Швидкість польоту
    public float lifetime = 3f;    // Через скільки секунд видалити

    void Start()
    {
        // БЕЗПЕЧНИЙ ЗНИЩЕННЯ: Ми використовуємо Invoke, щоб видалити об'єкт
        // тільки ОДИН раз і тільки через час lifetime. Це запобігає спробам
        // доступу до вже знищеного об'єкта.
        Invoke("DestroySelf", lifetime);
    }

    void Update()
    {
        // РУХ: Кожен кадр рухаємо кулю ВГОРУ по осі Y
        // Vector3.up — це напрямок (0, 1, 0)
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Якщо куля влучила в "Enemy" або "FallingObject"
        if (collision.CompareTag("Enemy") || collision.CompareTag("FallingObject"))
        {
            Destroy(collision.gameObject); // Знищуємо ціль
            
            // Якщо ми знищуємо саму кулю при влучанні, треба скасувати Invoke,
            // щоб не намагатися знищити її вдруге.
            CancelInvoke("DestroySelf");
            Destroy(gameObject);           // Знищуємо кулю
            Debug.Log("Влучання!");
        }
    }

    // ОКРЕМИЙ МЕТОД ДЛЯ ЗНИЩЕННЯ (щоб усе було чисто)
    void DestroySelf()
    {
        // Переконуємося, що ми не намагаємося знищити вже знищений об'єкт
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}