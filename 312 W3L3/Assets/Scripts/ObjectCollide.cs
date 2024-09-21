using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ObjectCollide : MonoBehaviour
{
    [SerializeField] Material matHit;
    [SerializeField] scorekeeping scoreKeeping;

    private HashSet<GameObject> collidedObjects = new HashSet<GameObject>();

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collidedObjects.Add(collision.gameObject);
            collision.gameObject.GetComponent<MeshRenderer>().material = matHit;
            scoreKeeping.addToScore();
        }
    }
}
