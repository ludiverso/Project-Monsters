using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger: " + other);
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.CollectCoin();
            Destroy(gameObject);
        }
    }
}
