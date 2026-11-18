using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money = 200;
    public int lives = 20;
    public int currentWave = 0;

    public UnityEvent onMoneyChanged;
    public UnityEvent onLivesChanged;

    void Awake()

    {
    Application.targetFrameRate = -1;//Kaelans Contributiion
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        onMoneyChanged?.Invoke();
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            onMoneyChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void LoseLife(int amount = 1)
    {
        lives -= amount;
        onLivesChanged?.Invoke();

        if (lives <= 0)
            GameOver();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;

        
    }
    
}
