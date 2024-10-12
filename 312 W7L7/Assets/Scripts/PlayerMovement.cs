using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody thisRigidbody;
    [SerializeField] float speedThrust;
    [SerializeField] float speedRot;

    Vector3 thrust;
    float rotateForce;

    float momentum;
    bool isStopped = false;

    [SerializeField] AudioSource soundThrust;

    public bool isCrashed = false;

    [SerializeField] ParticleSystem particleThrust;
    [SerializeField] ParticleSystem particleRightTurn;
    [SerializeField] ParticleSystem particleLeftTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCrashed)
        {
            Rotation();
            Thrust();
        }
    }

    private void Thrust()
    {
        ThrustInputDetection();

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

    private void ThrustInputDetection()
    {
        thrust = transform.up * Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") <= 0)
        {
            thrust *= 0;
            particleThrust.Stop();
            soundThrust.Stop();
        }
        else
        {
            if (!soundThrust.isPlaying)
            {
                particleThrust.Play();
                soundThrust.Play();
            }
        }
    }

    private void Rotation()
    {
        rotateForce = Input.GetAxis("Horizontal");
        thisRigidbody.AddTorque(-Vector3.forward * rotateForce * speedRot * 100 * Time.deltaTime);
        if (rotateForce == 0)
        {
            particleRightTurn.Stop();
            particleLeftTurn.Stop();
        }
        else if (rotateForce < 0)
        {
            particleLeftTurn.Play();
        }
        else
        {
            particleRightTurn.Play();
        }
    }
}