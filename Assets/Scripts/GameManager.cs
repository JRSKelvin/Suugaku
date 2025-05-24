using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private EquationGenerator equationGenerator;
    public string[] questions => equationGenerator.questions;
    public int[] correctPassKey => equationGenerator.correctPassKey;
    
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
        if (GameData.Instance != null)
        {
            if (GameData.Instance.difficulty == Difficulty.Easy) equationGenerator.GenerateEasyEquation();
            else equationGenerator.GenerateEquation();
        }
        else equationGenerator.GenerateEquation();
    }
}
