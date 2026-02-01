using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class dialogScript : MonoBehaviour
{
    private static TextMeshProUGUI dialogBox;
    private Queue<string> toDisplay = new Queue<string>();
    bool startDisplay = false;

    private void Start()
    {
        dialogBox = GameObject.FindGameObjectWithTag("dialogBox").GetComponentInChildren<TMPro.TextMeshProUGUI>();
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

    IEnumerator displayDialog()
    {
        while (toDisplay.Count > 0)
        {
            dialogBox.text += toDisplay.Dequeue();
            //Audio Sound
            yield return new WaitForSeconds(2f);
        }
        startDisplay = false;
    }
}
