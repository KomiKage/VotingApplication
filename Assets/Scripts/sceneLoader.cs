using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void loader(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
