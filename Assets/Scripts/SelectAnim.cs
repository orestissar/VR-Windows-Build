using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR

using UnityEditor;

#endif
using UnityEngine;


public class SelectAnim : MonoBehaviour
{
    int count = 0;
    Animator animator;
    void Start()
    {
        
        animator = GetComponent<Animator>();
       
    }
    private void Update()
    {
        if (count == 0)
        {
            Idletwist();
        }
        else if (count == 1)
        {
            CatwalkSequence();
        }
        else if (count == 2)
        {
            Catwalk();
        }
        else if (count == 3)
        {
            CatwalkTwist();
        }
        else
        {
            Idletwist();
        }
    }
    public void right()
    {
        count += 1;
        Debug.Log(count);
    }
    public void left()
    {
        count = count - 1;
    }

    public void play()
    {
        animator.enabled = true;
    }

    public void pause()
    {
        animator.enabled = false;
    }

    public void exitplay()
    {
        //EditorApplication.isPlaying = false;
        
    }

    //Animations
    void Idletwist()
    {
        animator.SetBool("Idle Twist", true);
    }

    void CatwalkSequence()
    {
        animator.SetBool("CatwalkSequence", true);
        animator.SetBool("Catwalk", false);
        animator.SetBool("CatwalkTwist", false);
    }

   void Catwalk()
    {
        animator.SetBool("CatwalkSequence", false);
        animator.SetBool("Catwalk", true);
        animator.SetBool("CatwalkTwist", false);
    }

    void CatwalkTwist()
    {
        animator.SetBool("CatwalkTwist", true);
        animator.SetBool("CatwalkSequence", false);
        animator.SetBool("Catwalk", false);

    }
}
