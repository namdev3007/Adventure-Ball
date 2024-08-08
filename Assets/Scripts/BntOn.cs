using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BntOn : MonoBehaviour
{
    public MovePlatform movePlatform;
    public MoveToWaypoint moveToWaypoint;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        animator.SetBool("On", true);
        movePlatform.enabled = true;
        moveToWaypoint.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         animator.SetBool("On", false);
         movePlatform.enabled = false;
         moveToWaypoint.enabled = true;
    }
}
