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
            //canMove = false;
            //Set it back to true after the interact is done.
        }
    }
    public void jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //jumps
        }
    }
}
