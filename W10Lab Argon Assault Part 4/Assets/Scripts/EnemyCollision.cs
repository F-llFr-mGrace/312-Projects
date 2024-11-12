using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"Ouch I, {gameObject.name}, am slain by {other.name}!");
        Destroy(gameObject);
    }
}
