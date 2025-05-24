using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Carousel : MonoBehaviour
{
    [SerializeField] string[] texts;
    [SerializeField] TextMeshProUGUI textObject;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;

    private int slideNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextButton.onClick.AddListener(NextSlide);
        previousButton.onClick.AddListener(PreviousSlide);
        textObject.text = texts[0];
    }

    void NextSlide()
    {
        if (slideNumber >= texts.Length - 1) return;
        textObject.text = texts[++slideNumber];
    }

    void PreviousSlide()
    {
        if (slideNumber <= 0) return;
        textObject.text = texts[--slideNumber];
    }
}
