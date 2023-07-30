using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private void Start()
    {
        EventManager.instance.onScoreIncreased += HandleScoreIncreased;

    }

    private void OnDestroy()
    {
        EventManager.instance.onScoreIncreased -= HandleScoreIncreased;
    }
    public void HandleScoreIncreased()
    {
        obj.GetComponent<Animator>().Play("Infant");

    }
}
