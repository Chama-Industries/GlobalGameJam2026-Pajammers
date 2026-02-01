using System.Collections;
using TMPro;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public QTE_Controller qteRef;
    public QTE_Trigger enemyAttack;
    public bool singleAttack = false;
    public int HP = 3;
    public TextMeshProUGUI winText;

    private void Awake()
    {
        qteRef = GetComponent<QTE_Controller>();
    }

    private void FixedUpdate()
    {
        if(singleAttack)
        {
            StartCoroutine(attack());
            qteRef.increaseDifficulty();
        }

        if(HP == 0)
        {
            winText.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    IEnumerator attack()
    {
        Instantiate(enemyAttack, this.gameObject.transform);
        singleAttack = false;
        yield return new WaitForSecondsRealtime(10.0f);
        singleAttack = true;
    }
}
