using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameUI;
    [SerializeField] private GameObject difficultyButton;
    [SerializeField] private GameObject startButton;
    [SerializeField] private TextMeshProUGUI explanationText;
    [SerializeField] private GameObject checkboxImage;

    private void Awake() {
        gameUI.DOFade(1f, 0.5f);
    }
    
    void Start()
    {
        startButton.GetComponent<Button>().onClick.AddListener(() => {
            AudioManager.Instance.PlayInGame();
            Loader.LoadLevel(Loader.Scene.GameScene);
        });
        explanationText.text = "Waktu main 5 menit, persamaan linear mudah";
    }

    public void ChangeDifficulty(GameObject sender)
    {
        if (sender.name == "HardButton")
        {
            // difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Hard";
            checkboxImage.transform.SetParent(sender.transform, false);
            checkboxImage.transform.localPosition = Vector3.zero;
            explanationText.text = "Waktu main 7 menit, persamaan linear lebih kompleks";
            GameData.Instance.SwapDifficulty(Difficulty.Hard);
        }
        else if (sender.name == "EasyButton")
        {
            // difficultyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Easy";
            checkboxImage.transform.SetParent(sender.transform, false);
            checkboxImage.transform.localPosition = Vector3.zero;
            explanationText.text = "Waktu main 5 menit, persamaan linear mudah";
            GameData.Instance.SwapDifficulty(Difficulty.Easy);
        }
    }
}
