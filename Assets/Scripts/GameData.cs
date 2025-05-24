using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public Difficulty difficulty { get; private set; } = Difficulty.Easy;

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

    public void SwapDifficulty(Difficulty difficulty)
    {
        this.difficulty = difficulty;
    }
}

public enum Difficulty
{
    Easy,
    Hard,
}