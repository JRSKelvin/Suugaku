using TMPro;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] digitTexts;
    private int[] currentCode = {0, 0, 0, 0};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateDisplay(); // Show initial numbers
    }

    // Swipe Up: Increase number
    public void IncreaseDigit(int index)
    {
        currentCode[index] = (currentCode[index] + 1) % 10; // Loop 0-9
        UpdateDisplay();
    }

    // Swipe Down: Decrease number
    public void DecreaseDigit(int index)
    {
        currentCode[index] = (currentCode[index] - 1 + 10) % 10; // Loop 9-0
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < 4; i++)
        {
            digitTexts[i].text = currentCode[i].ToString();
        }
    }

    public void Submit()
    {
        for (int i = 0; i < 4; i++)
        {
            if (currentCode[i] == GameManager.Instance.correctPassKey[i])
            {
                if (i == currentCode.Length - 1)
                {
                    Debug.Log("Padlock open");
                }
                else continue;
            }
        }
    }
}
