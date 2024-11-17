using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score;
    [SerializeField] TextMeshProUGUI textScore;
    public void IncreaseScore(int ammtToIncrease)
    {
        score += ammtToIncrease;
        //Debug.Log($"The new score is, {score}");
        textScore.text = ($"Score || {score}");
    }
}
