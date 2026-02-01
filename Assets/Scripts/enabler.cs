using UnityEngine;

public class enabler : MonoBehaviour
{
    public GameObject UI;
    public dialogScript dialogReference;
    public string dialog;

    private void Start()
    {
        try
        {
            UI = GameObject.FindGameObjectWithTag("UI");
            dialogReference = UI.GetComponent<dialogScript>();
        }
        catch 
        {
            throw new System.Exception("Did you add the UI Prefab to the scene?");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dialogReference.queueDialog(dialog);
            dialogReference.startDialog();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            dialogReference.queueDialog(dialog);
            dialogReference.startDialog();
        }
    }
}
