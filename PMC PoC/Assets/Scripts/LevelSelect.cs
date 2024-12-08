using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] GUIController GUIControllerScript;

    private bool levelComplete = false;

    private void OnEnable()
    {
        GUIControllerScript.WeAreWinningSignal += TriggerLevelComplete;
    }

    private void OnDisable()
    {
        GUIControllerScript.WeAreWinningSignal -= TriggerLevelComplete;
    }

    void Update()
    {
        if (levelComplete)
        {
            NextLevel();
        }
    }

    public void TriggerLevelComplete()
    {
        levelComplete = true;
    }

    void NextLevel()
    {
        levelComplete = false;

        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No more levels!");
        }

    }
}
