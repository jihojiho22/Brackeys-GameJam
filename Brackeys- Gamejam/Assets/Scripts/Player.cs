using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    public bool isIndoors = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
         if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            // animator.SetBool("isJumping", true);
        }
    }

    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        transform.LookAt(transform.position + new Vector3(moveHorizontal, 0, moveVertical));
        animator.SetBool("isWalking", moveHorizontal != 0 || moveVertical != 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Inside"))
        {
            isIndoors = true;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("isJumping", false);

        }

        if (collision.gameObject.CompareTag("Inside"))
        {
            isIndoors = false;
        }
    }

    
}
