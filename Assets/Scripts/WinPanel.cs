using TMPro;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Timer timer;
    private void OnEnable() {
        float timeRemaining = timer.timeRemaining;

        string timeRemainingText = FormatTime(Mathf.FloorToInt(timeRemaining));

        timerText.SetText(timeRemainingText);
        timer.StopTimer();
    }

    private string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        if (minutes > 0)
            return $"{minutes} menit {seconds} detik";
        else
            return $"{seconds} detik";
    }
}
