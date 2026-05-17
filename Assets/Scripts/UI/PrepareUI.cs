using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrepareUI : MonoBehaviour
{
    private Animator animator;

    private Action onComplete;
    private void Start() {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        //test

    }
    public void Show(Action action)
    {
        onComplete = action;
        animator.enabled = true;
    }
    void OnShowComplete()
    {
        onComplete?.Invoke();
    }
    // Start is called before the first frame update
   
}
