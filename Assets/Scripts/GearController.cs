using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("On", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("On", false);
    }
}
