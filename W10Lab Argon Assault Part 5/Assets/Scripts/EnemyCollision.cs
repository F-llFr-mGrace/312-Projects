using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;
    GameObject parentObj;
    int scorePerHit = 15;
    int hitCount = 0;

    Scoreboard scoreboard;

    private void Start()
    {
        parentObj = GameObject.FindWithTag("ParticleDump");
        scoreboard = FindObjectOfType<Scoreboard>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        hitCount += 1;
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentObj.transform;
        Debug.Log($"Ouch I, {gameObject.name}, am --HIT-- by {other.name}!");

        if (hitCount >= 3)
        {
            scoreboard.IncreaseScore(scorePerHit);
            Debug.Log($"Ouch I, {gameObject.name}, am --SLAIN-- by {other.name}!");
            Destroy(gameObject);
        }
    }
}
