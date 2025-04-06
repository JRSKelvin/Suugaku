using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquationGenerator : MonoBehaviour
{
    public string[] questions { get { return equationTexts; } }
    private string[] equationTexts = new string[4];
    [SerializeField] TextMeshProUGUI feedbackText;
    private List<(int, int)> correctAnswers = new List<(int, int)>(); // Store (x, y) integer solutions
    private int[] askedVariables = new int[4]; // 0 = ask for x, 1 = ask for y
    public string correctPassKey = ""; // The correct pass key

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateEquation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateEquation()
    {
        for (int i = 0; i < 4; i++)
        {
            // Step 1: Generate integer values for x and y
            int x = Random.Range(0, 9); // Ensure x is an integer
            int y = Random.Range(0, 9); // Ensure y is an integer

            // Step 2: Generate random coefficients for the equations
            int a1 = Random.Range(1, 6);
            int b1 = Random.Range(1, 6);
            int c1 = a1 * x + b1 * y; // Ensure the equation satisfies the integer solution

            int a2 = Random.Range(1, 6);
            int b2 = Random.Range(1, 6);
            int c2 = a2 * x + b2 * y; // Ensure integer solution

            // Store the correct (x, y)
            correctAnswers.Add((x, y));

            // Step 3: Randomly decide whether to ask for x or y
            askedVariables[i] = Random.Range(0, 2);

            string variable = askedVariables[i] == 0 ? "x" : "y";
            equationTexts[i] = $"{a1}x + {b1}y = {c1}\n{a2}x + {b2}y = {c2}\n\nFind {variable}.";
        }
    }

    public void CheckAnswer()
    {
        string playerPassKey = "";

        for (int i = 0; i < 4; i++)
        {
            int recognizedNumber = 0; // Get the recognized number
            if (recognizedNumber == -1)
            {
                feedbackText.text = "⚠️ Please write a valid number!";
                feedbackText.color = Color.yellow;
                return;
            }

            int correctValue = askedVariables[i] == 0 ? correctAnswers[i].Item1 : correctAnswers[i].Item2;

            playerPassKey += recognizedNumber.ToString();
        }

        if (playerPassKey == correctPassKey)
        {
            feedbackText.text = "✅ Correct! Pass Key Accepted!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "❌ Wrong Pass Key! Try Again.";
            feedbackText.color = Color.red;
        }
    }
}
