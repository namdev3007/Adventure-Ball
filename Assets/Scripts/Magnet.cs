using System.Collections;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject magnet;
    public GameObject magnetImg;
    public GameObject frameImg;
    public float maxDistance = 5f; // Khoảng cách tối đa mà nam châm có thể hút

    private bool activated = false;

    private void Start()
    {
        magnet = GameObject.FindGameObjectWithTag("Coin Detector");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            StartCoroutine(ActivateCoin());
            magnetImg.SetActive(false);
            frameImg.SetActive(false);
            activated = true;
        }
    }

    IEnumerator ActivateCoin()
    {
        magnet.SetActive(true);
        yield return null;
    }

    public bool IsActive()
    {
        return activated;
    }

    public bool CanAttract(Vector3 coinPosition, Vector3 playerPosition)
    {
        float distance = Vector3.Distance(coinPosition, playerPosition);
        return distance <= maxDistance;
    }
}
