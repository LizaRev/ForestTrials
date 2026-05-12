using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
   public float levelDuration = 120f;

   void Update()
    {
        if (levelDuration > 0)
        {
            levelDuration -= Time.deltaTime;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.UpdateTimerDisplay(levelDuration);
            }
        }
        else 
        {
            Debug.Log("Time's up");
            SceneManager.LoadScene("SampleScene");
        }
    }
}