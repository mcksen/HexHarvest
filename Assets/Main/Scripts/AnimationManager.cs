//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AnimationManager : MonoBehaviour
//{
//    [SerializeField] Animator animator;
//    void Start()
//    {
//        EventManager.instance.onScoreIncreased += HandleScoreIncreased;

//    }

//    private void OnDestroy()
//    {
//        EventManager.instance.onScoreIncreased -= HandleScoreIncreased;
//    }
//    private void HandleScoreIncreased()
//    {
//        animator.Play("Infant");
//    }
//}
