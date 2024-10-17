using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody thisRb;

    [SerializeField] float speedMove;
    [SerializeField] float speedTurn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            thisRb.AddRelativeForce(Vector3.up *  speedMove * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            thisRb.AddTorque(Vector3.forward * speedTurn * 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            thisRb.AddTorque(Vector3.forward * -speedTurn * 100 * Time.deltaTime);
        }
    }
}
