using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Loads the scene using LoadSceneMode.Additive
    public void LoadLevelSingle (int index)
    {
        SceneManagement.Instance.LoadSceneSingle(index);
    }

    // Loads the scene using LoadSceneMode.Single
    public void LoadLevelAdditive (int index)
    {
        SceneManagement.Instance.LoadSceneAdditive(index);
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
