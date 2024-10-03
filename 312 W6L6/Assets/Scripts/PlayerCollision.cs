using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Respawn"):
                Debug.Log("You're at respawn pad");
                break;
            case ("Finish"):
                Debug.Log("You're at a finish pad");
                break;
            default:
                Debug.Log("Rocket crash!");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
