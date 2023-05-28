using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        UpdateCursorVisibility();
    }

    private void UpdateCursorVisibility()
    {
        Cursor.visible = true;
        Cursor.lockState = true ? CursorLockMode.None : CursorLockMode.Locked;
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
