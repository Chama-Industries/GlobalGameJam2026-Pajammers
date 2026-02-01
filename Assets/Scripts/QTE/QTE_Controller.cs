using UnityEngine;

public class QTE_Controller : MonoBehaviour
{
    public GameObject qteText;
    public static float timeToMash = 4f;     // Time limit
    public static int pressesNeeded = 12;    // How many presses to win

    private float timer;
    private int pressCount;
    private bool qteActive = false;

    void Update()
    {
        if (qteActive)
        {
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.E))
            {
                pressCount++;
                Debug.Log("Presses: " + pressCount);
            }

            if (pressCount >= pressesNeeded)
            {
                Success();
            }

            if (timer <= 0)
            {
                Fail();
            }
        }
    }

    public void StartQTE()
    {
        qteText.SetActive(true);
        timer = timeToMash;
        pressCount = 0;
        qteActive = true;
    }

    void Success()
    {
        qteText.SetActive(false);
        qteActive = false;
        Debug.Log("You held on!");
    }

    void Fail()
    {
        qteText.SetActive(false);
        qteActive = false;
        Debug.Log("You fell!");
    }

    public void increaseDifficulty()
    {
        timeToMash -= 0.25f;
        pressesNeeded += 2;
    }
}
