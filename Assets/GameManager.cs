using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public TextMeshProUGUI foodText;  
    public TextMeshProUGUI timerText; 

    public int foodCollected = 0;

    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start() { UpdateUI(); }

    public void AddFood(int amount)
    {
        foodCollected += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (foodText != null) foodText.text = "Food: " + foodCollected;
    }

    public void UpdateTimerDisplay(float time)
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}