using System.Collections;
#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

public class Animations : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Idletwist()
    {       
        animator.SetBool("Idle Twist", true);
    }

    public void CatwalkSequence()
    {
        animator.SetBool("CatwalkSequence", true);
        animator.SetBool("Catwalk", false);
        animator.SetBool("CatwalkTwist", false);
    }

    public void Catwalk()
    {
        animator.SetBool("CatwalkSequence", false);
        animator.SetBool("Catwalk", true);
        animator.SetBool("CatwalkTwist", false);
    }

    public void CatwalkTwist()
    {
        animator.SetBool("CatwalkTwist", true);
        animator.SetBool("CatwalkSequence", false);
        animator.SetBool("Catwalk", false);
        
    }

}
