using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // Countdown from 60 seconds
    public TextMeshProUGUI timerText;
    private bool isStop = false;

    public static event Action OnTimerEnd;

    private void Awake() {
        if (GameData.Instance != null)
        {
            if (GameData.Instance.difficulty == Difficulty.Easy) timeRemaining = 300f;
            else timeRemaining = 420f;
        }
    }

    void Update()
    {
        if (timeRemaining > 0 && !isStop)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeRemaining = 0;
            OnTimerEnd?.Invoke();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StopTimer()
    {
        isStop = true;
    }

    public void ContinueTimer()
    {
        isStop = false;
    }
}
