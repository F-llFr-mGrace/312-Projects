using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedDTimeOffset;
    [SerializeField] Rigidbody thisRigidbody;

    float moveForBack;
    float moveLeftRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveForBack = Input.GetAxis("Vertical");
        moveLeftRight = Input.GetAxis("Horizontal");
        //Debug.Log(moveForBack + ", " + moveLeftRight);

        var moveDir = new Vector3(moveLeftRight , 0 , moveForBack);
        moveDir.Normalize();

        Debug.Log(Time.deltaTime);

        thisRigidbody.AddForce(moveDir * speed * speedDTimeOffset * Time.deltaTime);
    }
}
