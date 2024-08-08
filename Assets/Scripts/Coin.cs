using UnityEngine;

public class Coin : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 15f;

    CoinMove coinMove;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMove = gameObject.GetComponent<CoinMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin Detector"))
        {
            coinMove.enabled = true;
        }
    }
}