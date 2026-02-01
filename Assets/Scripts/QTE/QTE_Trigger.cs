using UnityEngine;

public class QTE_Trigger : MonoBehaviour
{
    // Reference to your QTE manager (object with QTE_Controller)
    public QTE_Controller qte;

    // This runs when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if it's the player
        if (other.CompareTag("Player"))
        {
            // Start the QTE
            qte.StartQTE();
        }
    }
}