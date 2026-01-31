using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
