using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorekeeping : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;

    float score = 0;
    float scoreMult = 1;
    float lastScored;
    float lastScoredOld;

    void Start()
    {
        lastScored = Time.time;
        lastScoredOld = Time.time;
        textScore.text = "Score: " + score;
    }

    public void addToScore(float scoreToAdd)
    {
        if (lastScored < float.Epsilon)
        {
            lastScored = Time.time;
            lastScoredOld = Time.time;
        }
        else
        {
            lastScored = Time.time;
            if (lastScored - lastScoredOld <= 5f)
            {
                scoreMult += 0.1f;
            }
            else
            {
                scoreMult = 1;
            }
            lastScoredOld = lastScored;
        }
        score += scoreToAdd;
        textScore.text = ("Score: " + score + " X " + scoreMult + " = " + score * scoreMult).ToString();
        score *= scoreMult;
    }
}
