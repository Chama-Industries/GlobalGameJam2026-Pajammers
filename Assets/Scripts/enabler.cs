using UnityEngine;

public class enabler : MonoBehaviour
{
    public GameObject UI;
    public dialogScript dialogReference;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        dialogReference = UI.GetComponent<dialogScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dialogReference.queueDialog("OWIIIIEEE");
            dialogReference.startDialog();
        }
    }
}
