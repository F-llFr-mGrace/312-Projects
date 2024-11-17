using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Transform parent;
    int scorePerHit = 15;
    int hitCount = 0;

    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        hitCount += 1;
        scoreboard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Debug.Log($"Ouch I, {gameObject.name}, am --HIT-- by {other.name}!");

        if (hitCount >= 3)
        {
            Debug.Log($"Ouch I, {gameObject.name}, am --SLAIN-- by {other.name}!");
            Destroy(gameObject);
        }
    }
}
