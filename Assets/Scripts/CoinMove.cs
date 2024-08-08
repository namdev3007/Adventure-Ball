using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coin coin;
    Magnet magnet;

    void Awake()
    {
        coin = gameObject.GetComponent<Coin>();
        magnet = GameObject.FindGameObjectWithTag("Coin Detector").GetComponent<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnet.IsActive() && magnet.CanAttract(transform.position, coin.playerTransform.position))
        {
            transform.position = Vector3.MoveTowards(transform.position, coin.playerTransform.position, coin.moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
