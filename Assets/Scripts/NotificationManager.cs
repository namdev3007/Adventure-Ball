using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    Animator animator;
    public static NotificationManager instance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        instance = this;
    }

    public void ActivateNotificationTrigger()
    {
        animator.SetTrigger("On");
    }
}
