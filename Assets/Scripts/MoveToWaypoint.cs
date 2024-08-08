using UnityEngine;

public class MoveToWaypoint : MonoBehaviour
{
    public Transform waypoint;
    public float speed = 5f; 


    private void Update()
    {

        Vector2 direction = (waypoint.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

 
        if (Vector2.Distance(transform.position, waypoint.position) < 0.1f)
        {
            enabled = false;
        }
    }
}
