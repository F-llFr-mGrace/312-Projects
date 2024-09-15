using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorekeeping : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;

    float score = 0;
    float scoreToAdd;

    void Start()
    {
        textScore.text = "Score: " + score;
    }

    public void addToScore(float scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = "Score: " + score;
    }
}
