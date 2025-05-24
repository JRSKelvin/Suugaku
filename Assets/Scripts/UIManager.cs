using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // [SerializeField] private EquationGenerator equationGenerator;
    [SerializeField] private Sprite[] number;
    [SerializeField] private GameObject openScrollButtonGameObject;
    [SerializeField] private GameObject closeScrollButtonGameObject;
    [SerializeField] private Button closePadlockPanelButton;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject equationPanel;
    [SerializeField] private GameObject equationPanelNumber;
    [SerializeField] private Button submitPassButton;
    [SerializeField] private GameObject padlockPanel;
    [SerializeField] private TextMeshProUGUI[] digitText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    void Start()
    {
        ObjectDetector2D.OnObjectDetected += ObjectDetected;
        ObjectDetector2D.OnObjectEmpty += ObjectLeft;
        Timer.OnTimerEnd += Lose;

        closeScrollButtonGameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            CloseEquationPanel();
        });

        closePadlockPanelButton.onClick.AddListener(() =>
        {
            ClosePadlockPanel();
        });

        submitPassButton.onClick.AddListener(() =>
        {
            CheckAnswer();
        });
    }

    void OnDestroy()
    {
        ObjectDetector2D.OnObjectDetected -= ObjectDetected;
        ObjectDetector2D.OnObjectEmpty -= ObjectLeft;
        Timer.OnTimerEnd -= Lose;
    }

    void CheckAnswer()
    {
        bool isCorrect = true;

        for (int i = 0; i < digitText.Length; i++)
        {
            string digit = digitText[i].text;
            if (digit != GameManager.Instance.correctPassKey[i].ToString())
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            ClosePadlockPanel();
            Win();
        }
        else
        {
            padlockPanel.GetComponent<RectTransform>().DOShakeAnchorPos(
                duration: 0.5f,
                strength: new Vector2(5, 5),
                vibrato: 10,
                randomness: 90,
                snapping: false,
                fadeOut: false
            );
        }
    }

    void ObjectDetected(GameObject detectedObject)
    {
        if (detectedObject.TryGetComponent<QuestionScroll>(out QuestionScroll scroll))
        {
            openScrollButtonGameObject.SetActive(true);
            openScrollButtonGameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            openScrollButtonGameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                OpenEquationPanel(GameManager.Instance.questions[scroll.questionNumber]);
                equationPanelNumber.GetComponent<Image>().sprite = number[scroll.questionNumber];
            });
        }
        if (detectedObject.CompareTag("Door"))
        {
            openScrollButtonGameObject.SetActive(true);
            openScrollButtonGameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            openScrollButtonGameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                OpenPadlockPanel();
            });
        }
        if (detectedObject.CompareTag("InteractableObject"))
        {
            if (detectedObject.GetComponent<InteractableObject>().isInteracted)
            {
                interactButton.SetActive(false);
                return;
            }

            interactButton.SetActive(true);
            interactButton.GetComponent<Button>().onClick.RemoveAllListeners();
            interactButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                detectedObject.GetComponent<InteractableObject>().Interact();
                interactButton.SetActive(false);
            });
        }
    }

    void ObjectLeft()
    {
        openScrollButtonGameObject.SetActive(false);
        interactButton.SetActive(false);
    }

    void OpenEquationPanel(string question)
    {
        equationPanel.SetActive(true);
        equationPanel.GetComponentInChildren<TextMeshProUGUI>().text = question;

    }

    void CloseEquationPanel()
    {
        equationPanel.SetActive(false);
    }

    void OpenPadlockPanel()
    {
        padlockPanel.SetActive(true);
    }

    void ClosePadlockPanel()
    {
        padlockPanel.SetActive(false);
    }

    void Win()
    {
        winPanel.SetActive(true);
        winPanel.transform.localScale = Vector3.zero;
        winPanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutCubic);
    }

    void Lose()
    {
        losePanel.SetActive(true);
        losePanel.transform.localScale = Vector3.zero;
        losePanel.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutCubic);
    }

    public void BackToMainMenu()
    {
        Loader.LoadLevel(Loader.Scene.HomeScene);
    }
 }
