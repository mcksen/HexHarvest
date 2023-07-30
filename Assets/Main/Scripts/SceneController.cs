
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneController", menuName = "Scriptable Objects/SceneController")]
public class SceneController : ScriptableObject
{
    public static SceneController instance;
    [SerializeField] private string game;
    [SerializeField] private string ui;
    [SerializeField] private string menu;
    [SerializeField] private string gameOver;
    [SerializeField] private string pause;
    [SerializeField] private string awake;
    [SerializeField] private string audioScene;


    List<string> scenesToUnload;

    public void Initialise()
    {
        instance = this;

        scenesToUnload = new List<string>();
        EventManager.instance.onOpenGame += HandleOpenGame;
        EventManager.instance.onNewGameSelected += HandleNewGameSelected;
        EventManager.instance.onMenuSelected += HandleMenuSelected;
        EventManager.instance.onPauseSelected += HandlePauseSelected;
        EventManager.instance.onResumeSelected += HandleResumeSelected;
        EventManager.instance.onDefeated += HandleDefeat;
    }
    private void onDestroy()
    {
        EventManager.instance.onOpenGame -= HandleOpenGame;
        EventManager.instance.onNewGameSelected -= HandleNewGameSelected;
        EventManager.instance.onMenuSelected -= HandleMenuSelected;
        EventManager.instance.onPauseSelected -= HandlePauseSelected;
        EventManager.instance.onResumeSelected -= HandleResumeSelected;
        EventManager.instance.onDefeated -= HandleDefeat;
    }

    // --------------------------------------------------------------------------------------
    // Event-dependant functions
    // --------------------------------------------------------------------------------------

    private void HandleNewGameSelected()
    {
        StartNewGame();
    }
    private void HandleDefeat()
    {
        LoseGame();
    }
    private void HandlePauseSelected()
    {
        PauseGame();
    }
    private void HandleResumeSelected()
    {
        UnpauseGame();
    }
    private void HandleMenuSelected()
    {
        ReturnToMenu();
    }





    // --------------------------------------------------------------------------------------
    // Scene Controller-speciefic functions
    // --------------------------------------------------------------------------------------

    public void HandleOpenGame()
    {

        LoadScene(menu, false);
        LoadScene(audioScene, true);
        LoadScene(game, true);
        scenesToUnload.Add(awake);
        Debug.Log("bbbbbbbbbbbbbbbbbbbb" + Time.frameCount);


    }
    public void StartNewGame()
    {
        UnloadScenes();
        LoadScene(ui, false);

    }

    public void PauseGame()
    {
        UnloadScenes();
        LoadScene(pause, false);


    }


    public void UnpauseGame()
    {
        SceneManager.UnloadSceneAsync(pause);
        scenesToUnload.Remove(pause);
        LoadScene(ui, false);

    }

    public void LoseGame()
    {
        UnloadScenes();
        LoadScene(gameOver, false);


    }

    public void ReturnToMenu()
    {
        UnloadScenes();
        LoadScene(menu, false);
    }




    public void LoadScene(string name, bool isPermanent)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        if (!isPermanent)
        {
            scenesToUnload.Add(name);
        }
        Debug.Log("pop" + Time.frameCount);
    }

    public void UnloadScenes()
    {
        if (scenesToUnload != null)
        {
            foreach (string i in scenesToUnload)
            {
                SceneManager.UnloadSceneAsync(i);

            }
            scenesToUnload.Clear();
        }
    }

}

