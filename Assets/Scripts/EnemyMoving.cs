using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    Rigidbody2D rigidbody2;
    private Transform currentPont;
    public float speed = 3f;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        currentPont = pointB.transform;
    }
}
