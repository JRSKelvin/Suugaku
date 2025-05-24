using UnityEngine;
using DG.Tweening;

public class HomeScreenUIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup gameUI;
    [SerializeField] GameObject tutorialPanel;
    public void Play()
    {
        gameUI.DOFade(0f, 0.5f)
            .OnComplete(() => {
                //Swap to difficulty selector
                Loader.LoadLevel(Loader.Scene.OptionScene);
            });
    }

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }
}
