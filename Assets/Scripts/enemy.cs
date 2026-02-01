using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public QTE_Controller qteRef;
    public QTE_Trigger enemyAttack;
    public bool singleAttack = false;

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
    }

    IEnumerator attack()
    {
        Instantiate(enemyAttack, this.gameObject.transform);
        singleAttack = false;
        yield return new WaitForSecondsRealtime(10.0f);
        singleAttack = true;
    }
}
