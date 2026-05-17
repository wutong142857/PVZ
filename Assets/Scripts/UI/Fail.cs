using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Hide();
    }
    
    public void Show()
    {
      animator.enabled = true;
    }
     void Hide()
    {
        animator.enabled = false;
    }
   
}
