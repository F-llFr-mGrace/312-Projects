using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCollide : MonoBehaviour
{
    [SerializeField] Material matHit;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            if (!collision.gameObject.CompareTag("Wall"))
            {
                collision.gameObject.GetComponent<MeshRenderer>().material = matHit;
            }
        }
    }
}
