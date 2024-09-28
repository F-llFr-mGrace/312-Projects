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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thrust = transform.up * Input.GetAxis("Vertical");
        rotateForce = Input.GetAxis("Horizontal");

        thisRigidbody.AddForce(thrust * speedThrust * 100 * Time.deltaTime);
        thisRigidbody.AddTorque(-Vector3.forward * rotateForce * speedRot * 100 * Time.deltaTime);
    }
}
