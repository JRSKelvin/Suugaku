using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string[] questions { get { return equationTexts; } }
    private string[] equationTexts = new string[4];
    private int[] askedVariables = new int[4]; // 0 = ask for x, 1 = ask for y
    public int[] correctPassKey { get; private set; } // The correct pass key
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }

    void Start()
    {
        correctPassKey = new int[4];
        GenerateEquation();
        GenerateEasyEquation();
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

            // Step 3: Randomly decide whether to ask for x or y
            askedVariables[i] = Random.Range(0, 2);
            correctPassKey[i] = askedVariables[i] == 0 ? x : y ;
            string variable = askedVariables[i] == 0 ? "x" : "y";
            equationTexts[i] = $"{FormatCoefficient(a1)}x + {FormatCoefficient(b1)}y = {c1}\n{FormatCoefficient(a2)}x + {FormatCoefficient(b2)}y = {c2}\n\nFind {variable}.";
        }
    }

    public void GenerateEasyEquation()
    {
        for (int i = 0; i < 4; i++)
        {
            // Randomly generate x and y values between 0-9
            int x = Random.Range(1, 10);
            int y = Random.Range(1, 10);

            // Compute sums for the two equations
            int sum1 = x + y;
            int sum2 = x - y;

            askedVariables[i] = Random.Range(0, 2);
            correctPassKey[i] = askedVariables[i] == 0 ? x : y ;
            string variable = askedVariables[i] == 0 ? "x" : "y";

            // Create equation strings
            equationTexts[i] = $"x + y = {sum1}\nx - y = {sum2}\n\nFind {variable}.";
        }
    }

    private string FormatCoefficient(int coef)
    {
        return (coef == 1) ? "" : coef.ToString();
    }
}
