using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAwakeSettings : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] private EventManager eventManager;
    private void Awake()
    {

        Time.timeScale = 0;
        eventManager.Initialise();
        sceneController.Initialise();
        sceneController.OpenGame();
    }
}
