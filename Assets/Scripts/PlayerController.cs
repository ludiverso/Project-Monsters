using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    private Rigidbody2D rb;
    private Vector2 move;

    public int coinsCollected = 0;
    public float moveSpeed = 3.0f;

    public void Start()
    {
        moveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        Debug.Log("Move: " + move);

    }

    public void FixedUpdate()
    {
        Vector2 position = rb.position + (moveSpeed * Time.deltaTime * move);
        rb.MovePosition(position);

    }

    public void CollectCoin()
    {
        coinsCollected++;
    }
}
