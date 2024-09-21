using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorekeeping : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] TextMeshProUGUI textScoreMultCountdown;

    float score = 0;
    float scoreToAdd = 0;
    float objectsHitInCombo = 0;
    [SerializeField] float timeCombo;
    float lastScored = -1;

    bool currentCombo = false;

    void Start()
    {
        lastScored = -1 - timeCombo;
        textScore.text = "Score: " + score;
    }

    void Update()
    {
        if ((lastScored + timeCombo) - Time.time > 0f)
        {
            textScoreMultCountdown.text = ((lastScored + timeCombo) - Time.time).ToString();
            currentCombo = true;
        }
        else
        {
            if (currentCombo)
            {
                score += scoreToAdd;
                objectsHitInCombo = 0;
                scoreToAdd = 0;
            }
            textScoreMultCountdown.text = (0).ToString();
            currentCombo = false;
        }
        if (currentCombo)
        {
            textScore.text = ("Score: " + score + " + " + scoreToAdd + " = " + (score + scoreToAdd)).ToString();
        }
        else
        {
            textScore.text = ("Score: " + score);
        }
    }

    public void addToScore()
    {
        lastScored = Time.time;
        objectsHitInCombo += 1;
        scoreToAdd += objectsHitInCombo;
    }
}
