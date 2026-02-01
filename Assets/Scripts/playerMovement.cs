using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Variable that dictates player speed
    public float speed = 0.1f;

    // Variables that dictate movement direction
    protected float hIn;
    protected float vIn;
    Vector3 movementDirection;
    public bool threeDMove = true;
    public bool canMove = true;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        interact();
        jump();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            if (threeDMove)
            {
                hIn = Input.GetAxis("Horizontal");
                vIn = Input.GetAxis("Vertical");
            }
            else
            {
                hIn = Input.GetAxis("Horizontal");
            }

            movementDirection = new Vector3(hIn, 0.0f, vIn);
            movementDirection.Normalize();

            transform.Translate(movementDirection * speed);
        }
    }

    public void interact()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            //this would do seomthing relative to puzzles
        }
    }
    public void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(new Vector3(0.0f, 10.0f, 0.0f), ForceMode.Impulse);
        }
    }

    public bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 2.0f);
    }

    public void changeDimensionalMovement()
    {
        threeDMove = !threeDMove;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        rb.linearVelocity = Vector3.zero;
        vIn = 0.0f;
    }
}
