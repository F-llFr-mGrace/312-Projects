using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrop : MonoBehaviour
{
    Vector3 oldPos;

    bool checkIdle = true;

    void Start()
    {
        oldPos = transform.position;
    }

    void Update()
    {
        if (checkIdle)
        {
            float ranTime = Random.Range(1, 10);
            Invoke("dropCube", ranTime);
            checkIdle = false;
        }
    }

    void dropCube()
    {
        var newPos = transform.position;
        newPos.y = transform.position.y + 10;
        this.transform.SetPositionAndRotation(newPos, transform.rotation);

        checkIdle = true;
    }
}
