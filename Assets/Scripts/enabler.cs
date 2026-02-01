using UnityEngine;

public class enabler : MonoBehaviour
{
    public GameObject UI;
    public dialogScript dialogReference;
    public string dialog;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
        dialogReference = UI.GetComponent<dialogScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dialogReference.queueDialog(dialog);
            dialogReference.startDialog();
        }
    }
}
