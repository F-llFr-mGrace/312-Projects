using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] Rigidbody car;

    [SerializeField] float speedMove = 1;
    [SerializeField] float speedTurn = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical") * speedMove * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * speedTurn * Time.deltaTime;
        Debug.Log($"Move: {move}, Turn: {turn}");
        car.AddForce(this.transform.right * move * Time.deltaTime);
        car.AddTorque(this.transform.up * turn * Time.deltaTime);
        //car.AddForce();
        var lockedAxis = this.transform.rotation;
        lockedAxis.x = 0; lockedAxis.z = 0;
        this.transform.SetPositionAndRotation(this.transform.position, lockedAxis);
    }
}
