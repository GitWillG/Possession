using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void NextLevel ()
    {
        SceneManagement.Instance.firstLevel++;
    }

    // Loads the scene using LoadSceneMode.Additive
    public void LoadLevelSingle ()
    {
        if (SceneManagement.Instance.firstLevel == SceneManager.sceneCountInBuildSettings)
        {
        NextLevel();
        SceneManagement.Instance.LoadSceneSingle(SceneManagement.Instance.firstLevel);
        LoadLevelAdditive();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    // Loads the scene using LoadSceneMode.Single
    public void LoadLevelAdditive ()
    {
        SceneManagement.Instance.LoadSceneAdditive(1);
        SceneManagement.Instance.LoadSceneAdditive(2);

    }

    // Quits the applicaiton
    public void QuitGame()
    {
        SceneManagement.Instance.QuitGame();
    }

    // Plays an audio file based on string input
    public void PlayAudio(string name)
    {
        AudioManager.Instance.PlaySound(name);
    }

}
