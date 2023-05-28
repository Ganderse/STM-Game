using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        UpdateCursorVisibility();

        //SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
        SceneManager.UnloadSceneAsync(2);
    }

    private void UpdateCursorVisibility()
    {
        Cursor.visible = true;
        Cursor.lockState = true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void NewReflexGame()
    {
        Debug.Log("Scene selected : Reflex Game" );
        SceneManager.LoadScene(1);
    }

    public void NewQuickMathGame()
    {
        Debug.Log("Scene selected : Quick Math Game");
        SceneManager.LoadScene(2);
    }


    public void NewGame()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
