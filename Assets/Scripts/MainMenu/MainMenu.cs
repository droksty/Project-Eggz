using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    /// Functions ///

    public void StartNormal()
    {
        Eggstravaganza.isEndless = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void StartEndless()
    {
        Eggstravaganza.isEndless = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadSettings()
    {
        Debug.Log("Loading Settings..");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
