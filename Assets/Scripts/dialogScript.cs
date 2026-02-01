using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class dialogScript : MonoBehaviour
{
    private static TextMeshProUGUI HUDBox;
    private static GameObject HUDRef;
    private static TextMeshProUGUI dialogBox;
    private static GameObject dialogRef;
    private static TextMeshProUGUI cutsceneBox;
    private static GameObject cutsceneRef;
    private static Queue<string> toDisplay = new Queue<string>();
    static bool startDisplay = false;

    private void Start()
    {
        HUDRef = GameObject.FindGameObjectWithTag("HUDBox");
        HUDBox = HUDRef.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        dialogRef = GameObject.FindGameObjectWithTag("dialogBox");
        dialogBox = dialogRef.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        dialogRef.SetActive(false);

        cutsceneRef = GameObject.FindGameObjectWithTag("cutsceneBox");
        cutsceneBox = cutsceneRef.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        cutsceneRef.SetActive(false);
    }

    public void queueDialog(string dialog)
    {
        while (dialog != "")
        {
            toDisplay.Enqueue(dialog.Substring(0, 1));
            dialog = dialog.Substring(1, dialog.Length - 1);
        }
    }

    public void startDialog()
    {
        if (!dialogRef.activeInHierarchy)
        {
            dialogRef.SetActive(true);
        }
        dialogBox.text = "";
        startDisplay = true;
    }

    private void FixedUpdate()
    {
        if (startDisplay)
        {
            StartCoroutine(displayDialog());
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            dialogRef.SetActive(false);
            toDisplay.Clear();
        }
    }

    IEnumerator displayDialog()
    {
        while (toDisplay.Count > 0)
        {
            dialogBox.text += toDisplay.Dequeue();
            //Audio Sound
            yield return new WaitForSeconds(2f);
        }
        startDisplay = false;
        //close dialog box after some time
    }
}
