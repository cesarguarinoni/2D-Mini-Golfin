using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI strokeUI;
    [Space(10)]
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private TextMeshProUGUI levelCompletedStrokeUI;
    [Space(10)]
    [SerializeField] private GameObject gameOverUI;

    [Header("Attributes")]
    [SerializeField] private int maxStrokes;   // Changed to int

    private int strokes;
    [HideInInspector] public bool outOfStrokes;
    [HideInInspector] public bool levelCompleted;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        UpdateStrokeUI();
    }

    public void IncreaseStroke()
    {
        if (levelCompleted || outOfStrokes)
            return;

        strokes++;
        UpdateStrokeUI();

        if (strokes >= maxStrokes)
        {
            outOfStrokes = true;
            GameOver();
        }
    }

    public void LevelComplete()
    {
        if (levelCompleted)
            return;

        levelCompleted = true;
        levelCompleteUI.SetActive(true);

        levelCompletedStrokeUI.text =
            strokes > 1
            ? "You putted in " + strokes + " strokes!"
            : "You got a hole in 1!";
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void UpdateStrokeUI()
    {
        strokeUI.text = strokes + "/" + maxStrokes;
    }
}