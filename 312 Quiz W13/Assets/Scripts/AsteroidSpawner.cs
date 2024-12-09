using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAsteroid", GenerateNewTime());
    }

    private void SpawnAsteroid()
    {
        Instantiate(asteroid, transform);
        Invoke("SpawnAsteroid", GenerateNewTime());
    }

    private static float GenerateNewTime()
    {
        float randomTime = Random.Range(3f, 5f);
        return randomTime;
    }
}
