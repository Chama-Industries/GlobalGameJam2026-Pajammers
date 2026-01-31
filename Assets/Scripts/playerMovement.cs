using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Variable that dictates player speed
    public float speed = 0.1f;

    // Variables that dictate movement direction
    protected float hIn;
    protected float vIn;
    Vector3 movementDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hIn = Input.GetAxis("Horizontal");
        vIn = Input.GetAxis("Vertical");

        movementDirection = new Vector3(hIn, 0.0f, vIn);

        transform.Translate(movementDirection * speed);
    }
}
