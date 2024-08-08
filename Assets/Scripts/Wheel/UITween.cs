using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    [SerializeField] GameObject tweenTest;

    private void Start()
    {
        LeanTween.rotateAround(tweenTest, Vector3.forward, -360, 10f).setLoopClamp();
    }
}
