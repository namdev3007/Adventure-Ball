using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BntPack3Controller : MonoBehaviour
{
    private Animator animator;
    private BntPack2Controller btPack2Controller;
    private BntPackController btPackController;
    private BntPack4Controller btPack4Controller;

    private void Start()
    {
        animator = GetComponent<Animator>();
        btPack2Controller = Object.FindFirstObjectByType<BntPack2Controller>();
        btPackController = Object.FindFirstObjectByType<BntPackController>();
        btPack4Controller = Object.FindFirstObjectByType<BntPack4Controller>();
    }

    public void OnButtonClicked3()
    {
        animator.SetBool("Disabled", false);
        btPackController.DisableButton();
        btPack2Controller.DisableButton();
        btPack4Controller.DisableButton();
    }

    public void DisableButton3()
    {
        animator.SetBool("Disabled", true);
    }
}
