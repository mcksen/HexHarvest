using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAwakeSettings : MonoBehaviour
{
    [SerializeField] SceneController sceneController;

    private void Awake()
    {

        sceneController.OpenGame();

    }
}
