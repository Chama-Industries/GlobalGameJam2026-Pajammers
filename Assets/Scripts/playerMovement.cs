using TMPro;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Variable that dictates player speed
    public float speed = 0.1f;
    public int HP = 3;
    private int comparativeHP;

    // Variables that dictate movement direction
    protected float hIn;
    protected float vIn;
    Vector3 movementDirection;
    public bool threeDMove = true;
    public bool canMove = true;

    Rigidbody rb;

    private static TextMeshProUGUI HUDBox;
    private static GameObject HUDRef;

    public TextMeshProUGUI loseText;

    private void Start()
    {
        comparativeHP = HP;
        rb = GetComponent<Rigidbody>();

        HUDRef = GameObject.FindGameObjectWithTag("HUDBox");
        HUDBox = HUDRef.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        HUDBox.text += " " + HP;
    }

    private void Update()
    {
        interact();
        jump();

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
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
        if(comparativeHP != HP)
        {
            HUDBox.text = "Health: " + HP;
            comparativeHP = HP;
        }
        if(HP == 0)
        {
            loseText.gameObject.SetActive(true);
            Destroy(this.gameObject);
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
