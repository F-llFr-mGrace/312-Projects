using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x * speed * 10 * Time.deltaTime;
        float verticalThrow = movement.ReadValue<Vector2>().y * speed * 10 * Time.deltaTime;

        /*
        float horizontalThrow = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");
        */

        Debug.Log(horizontalThrow + ", " + verticalThrow);

        transform.localPosition = new Vector3
            (
            transform.localPosition.x + horizontalThrow,
            transform.localPosition.y + verticalThrow,
            transform.localPosition.z
            );
    }
}
