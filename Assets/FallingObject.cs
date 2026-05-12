using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 5f; // Швидкість падіння

    void Update()
    {
        // Рухаємо об'єкт вниз кожний кадр
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Якщо фрукт впав дуже низько (наприклад, Y = -20) і ти в нього не влучила,
        // він видаляється сам, щоб не забивати гру
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }

    // Цей метод спрацьовує, коли в фрукт влучає куля
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Перевіряємо, чи в об'єкт влучила саме куля (тег має бути Bullet)
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Влучання у фрукт!");
            
            // Знищуємо кулю
            Destroy(other.gameObject);
            
            // Знищуємо сам фрукт
            Destroy(gameObject);
        }
    }
}