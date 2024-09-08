using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}