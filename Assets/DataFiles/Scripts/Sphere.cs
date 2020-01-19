using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("Click");
    }
}
