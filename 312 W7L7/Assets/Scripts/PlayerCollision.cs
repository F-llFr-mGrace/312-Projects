using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] BoxCollider thisCollider;

    [SerializeField] ParticleSystem particleSuccess;
    [SerializeField] ParticleSystem particleCrash;

    [SerializeField] PlayerMovement scriptPlayerMovement;

    bool isCrashed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        if (Input.GetKey(KeyCode.C))
        {
            thisCollider.enabled = false;
        }
        else
        {
            thisCollider.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Respawn"):
                Debug.Log("You're at respawn pad");
                break;
            case ("Finish"):
                Invoke("LoadNextLevel", 2f);
                particleSuccess.Play();
                break;
            default:
                particleCrash.Play();
                if (!isCrashed)
                {
                    isCrashed = true;
                    scriptPlayerMovement.isCrashed = true;
                    Invoke("ReLoadLevel", 1f);
                }
                break;
        }
    }

    private void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}