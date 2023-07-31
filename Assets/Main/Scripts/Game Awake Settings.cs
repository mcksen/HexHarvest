using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAwakeSettings : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private ScoreManager scoreManager;
    private void Awake()
    {

        Time.timeScale = 0;
        eventManager.Initialise();
        sceneController.Initialise();
        scoreManager.Instantiate();
        EventManager.instance.HandleOpenGame();

    }
}
