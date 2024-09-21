using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] Rigidbody thisRigidbody;
    [SerializeField] MeshRenderer thisMeshRenderer;
    [SerializeField] float waitTime;

    bool timerActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime && !timerActivated)
        {
            timerActivated = true;
            thisRigidbody.useGravity = true;
            thisMeshRenderer.enabled = true;
        }
    }
}
