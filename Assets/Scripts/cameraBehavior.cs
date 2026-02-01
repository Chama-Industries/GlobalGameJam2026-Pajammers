using UnityEditor.Rendering;
using UnityEngine;

public class cameraBehavior : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    bool followPlayer = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (followPlayer)
        {
            transform.position = player.transform.position + offset;
        }
    }

    public void changeOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }

    public void toggleFollow()
    {
        followPlayer = !followPlayer;
    }
}
