using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;


    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
        RefreshScoreTextUI();
    }


    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshScoreTextUI();
    }


    private void RefreshScoreTextUI()
    {
        scoreText.text = "Score: " + score;
    }
}
