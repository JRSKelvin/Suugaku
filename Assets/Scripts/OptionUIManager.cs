using TMPro;
using UnityEngine;

public class OptionUIManager : MonoBehaviour
{
    [SerializeField] private GameObject difficultyButton;

    public void ChangeDifficulty()
    {
        if (GameData.Instance.difficulty == Difficulty.Easy)
        {
            difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Hard";
        }
        else
        {
            difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Easy";
        }

        GameData.Instance.SwapDifficulty();
    }
}
