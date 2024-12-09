using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"I, --{gameObject}-- have collided with, --{collision.gameObject}--");
            Destroy(gameObject);
        }
    }
}
