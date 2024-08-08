using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector2 checkPointPos;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        checkPointPos = transform.position;
    }
    
    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }

    IEnumerator Respawn(float duration)
    {

        yield return new WaitForSeconds(duration);

    }    
}
