using UnityEngine;
using UnityEngine.UI; // Обязательно для текста
using UnityEngine.SceneManagement; // Для перехода на уровни

public class Collector : MonoBehaviour
{
    public int score = 0;
    public Text scoreDisplay; // Сюда перетянем текст из Canvas

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Если коснулись объекта с тегом Material
        if (other.CompareTag("Material"))
        {
            score++; // Добавляем +1
            scoreDisplay.text = "Собрано: " + score + " / 7"; // Обновляем надпись
            Destroy(other.gameObject); // Удаляем гриб

            if (score >= 7)
            {
                Debug.Log("Все собрано! Переход...");
                Invoke("NextLevel", 2f); // Загружаем след. уровень через 2 сек
            }
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level 2"); // Убедись, что сцена называется именно так
    }
}