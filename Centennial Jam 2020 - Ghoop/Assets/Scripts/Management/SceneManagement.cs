using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SceneManagement : MonoBehaviour
{
    private static SceneManagement _instance;
    public static SceneManagement Instance { get { return _instance; } }

    public int firstLevel = 3;
    public GameObject pauseMenu;

     #region Methods
    void Awake()
    {
        // Singleton Implementation
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            //Debug.Log("Instance was found");
        }
        else
        {
            _instance = this;
            //Debug.Log("Instance was not found");
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(SceneManager.GetActiveScene().name+ " " + SceneManager.GetSceneByName("Main Menu Scene").name);
            pausegame();
        }

    }

    // Loads the scene using LoadSceneMode.Additive
    public void LoadSceneAdditive(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
        //Debug.Log(sceneIndex + " was loaded");
        Time.timeScale = 1;
    }

    // Loads the scene using LoadSceneMode.Single
    public void LoadSceneSingle(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        //Debug.Log(sceneIndex + " was loaded");
        Time.timeScale = 1;
    }

    // Quits the application
    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("Game Successfully Closed");
    }

    public void loadMain()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
        firstLevel = 3;
    }
    public void restart()
    {
        firstLevel--;
        LoadSceneSingle(firstLevel);
        LoadSceneAdditive(1);
        LoadSceneAdditive(2);
        pauseMenu.SetActive(false);
        firstLevel++;

    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void pausegame()
    {
        if (SceneManager.GetActiveScene().name != SceneManager.GetSceneByName("Main Menu Scene").name)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);

        }
    }
    #endregion 
}
