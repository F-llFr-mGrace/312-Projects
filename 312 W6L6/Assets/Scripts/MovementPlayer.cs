using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody thisRigidbody;
    [SerializeField] float speedThrust;
    [SerializeField] float speedRot;

    Vector3 thrust;
    float rotateForce;

    float momentum;
    bool isStopped = false;

    [SerializeField] AudioSource soundThrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateForce = Input.GetAxis("Horizontal");
        thisRigidbody.AddTorque(-Vector3.forward * rotateForce * speedRot * 100 * Time.deltaTime);

        thrust = transform.up * Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") <= 0)
        {
            thrust *= 0;
            soundThrust.Stop();
        }
        else
        {
            if (!soundThrust.isPlaying)
            {
                soundThrust.Play();
            }
        }
        

        if (!Input.GetKey(KeyCode.Space))
        {
            if (isStopped)
            {
                thisRigidbody.useGravity = true;
                thisRigidbody.velocity = transform.up * momentum;
            }
            thisRigidbody.AddForce(thrust * speedThrust * 100 * Time.deltaTime);
            isStopped = false;
        }
        else
        {
            if (!isStopped)
            {
                thisRigidbody.useGravity = false;
                momentum = thisRigidbody.velocity.magnitude;
                isStopped = true;
            }
            thisRigidbody.velocity = Vector3.zero;
        }
    }
}
