 using UnityEngine;

public class QTE_Trigger : MonoBehaviour
{
    // Reference to your QTE manager (object with QTE_Controller)
    public QTE_Controller qte;

    private void Awake()
    {
        qte = GameObject.FindGameObjectWithTag("enemy").GetComponent<QTE_Controller>();
    }

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(-0.1f, 0.0f, 0.0f);
    }
    // This runs when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if it's the player
        if (other.gameObject.tag == "player")
        {
            // Start the QTE
            qte.StartQTE();
            Destroy(this.gameObject, 2.0f);
        }
    }
}