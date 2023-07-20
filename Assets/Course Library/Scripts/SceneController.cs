
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneController", menuName = "Scriptable Objects/SceneController")]
public class SceneController : ScriptableObject
{
    [SerializeField] private string game;
    [SerializeField] private string ui;
    [SerializeField] private string menu;
    [SerializeField] private string gameOver;
    [SerializeField] private string pause;
    [SerializeField] private string awake;


    List<string> scenesToUnload = new List<string>();

    public void OpenGame()
    {
        scenesToUnload.Add(awake);
        LoadScene(menu, false);

        LoadScene(game, true);
        Time.timeScale = 0;
    }
    public void StartNewGame()
    {
        UnloadScenes();
        LoadScene(ui, false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        LoadScene(pause, false);

        Time.timeScale = 0;
    }


    public void UnpauseGame()
    {
        SceneManager.UnloadSceneAsync(pause);
        scenesToUnload.Remove(pause);
        Time.timeScale = 1;
    }

    public void LoseGame()
    {
        UnloadScenes();
        LoadScene(gameOver, false); ;
        Time.timeScale = 0;
    }

    public void ReturnToMenu()
    {
        UnloadScenes();
        LoadScene(menu, false);
    }

    public void ExitGame()
    {
        Application.Unload();
        Application.Quit();
    }


    public void LoadScene(string name, bool isPermanent)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        if (!isPermanent)
        {
            scenesToUnload.Add(name);
        }
    }

    public void UnloadScenes()
    {
        foreach (string i in scenesToUnload)
        {
            SceneManager.UnloadSceneAsync(i);

        }
        scenesToUnload.Clear();
    }

}

