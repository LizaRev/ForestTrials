using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrystalsCollector : MonoBehaviour
{
    public int count = 0;
    public TextMeshProUGUI scoreDisplay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Material")) 
        {
            count++;
            scoreDisplay.text = "Score: " + count + "/7"; 
            Destroy(other.gameObject);

            if(count >= 7)
            {
                UnityEngine.Debug.Log("You win!");
                Invoke("NextLevel", 2f); 
            }
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}