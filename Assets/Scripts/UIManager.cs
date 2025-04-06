using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // [SerializeField] private EquationGenerator equationGenerator;
    [SerializeField] private GameObject openScrollButtonGameObject;
    [SerializeField] private GameObject closeScrollButtonGameObject;
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject equationPanel;
    [SerializeField] private GameObject padlockPanel;
    [SerializeField] private GameObject losePanel;
    void Start()
    {
        ObjectDetector2D.OnObjectDetected += ObjectDetected;
        ObjectDetector2D.OnObjectEmpty += ObjectLeft;
        Timer.OnTimerEnd += Lose;
    }

    void OnDestroy()
    {
        ObjectDetector2D.OnObjectDetected -= ObjectDetected;
        ObjectDetector2D.OnObjectEmpty -= ObjectLeft;
        Timer.OnTimerEnd -= Lose;
    }

    void ObjectDetected(GameObject detectedObject) 
    {
        if (detectedObject.TryGetComponent<QuestionScroll>(out QuestionScroll scroll)) {
            openScrollButtonGameObject.SetActive(true);
            openScrollButtonGameObject.GetComponent<Button>().onClick.AddListener(() => {
                OpenEquationPanel(GameManager.Instance.questions[scroll.questionNumber]);
            });
            closeScrollButtonGameObject.GetComponent<Button>().onClick.AddListener(() => {
                CloseEquationPanel();
            });
        }
        else if (detectedObject.CompareTag("Door"))
        {
            openScrollButtonGameObject.SetActive(true);
            openScrollButtonGameObject.GetComponent<Button>().onClick.AddListener(() => {
                OpenPadlockPanel();
            });
        }
        else if (detectedObject.CompareTag("InteractableObject"))
        {
            if (detectedObject.GetComponent<InteractableObject>().isInteracted)
            {
                interactButton.SetActive(false);
                return;
            }

            interactButton.SetActive(true);
            interactButton.GetComponent<Button>().onClick.AddListener(() => {
                detectedObject.GetComponent<InteractableObject>().Interact();
            });
        }
    }

    void ObjectLeft()
    {
        openScrollButtonGameObject.SetActive(false);
        interactButton.SetActive(false);
    }

    void OpenEquationPanel(string question) {
        equationPanel.SetActive(true);
        equationPanel.GetComponentInChildren<TextMeshProUGUI>().text = question;
    }

    void CloseEquationPanel() {
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

    void Lose()
    {
        losePanel.SetActive(true);
    }
 }
