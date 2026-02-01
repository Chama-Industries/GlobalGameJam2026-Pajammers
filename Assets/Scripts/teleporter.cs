using Unity.VisualScripting;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Camera mainCam;
    public GameObject Player;
    public GameObject desiredPlayerPosition;
    public GameObject desiredCameraPosition;

    private void Start()
    {
        mainCam = Camera.main;
        Player = GameObject.FindGameObjectWithTag("player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Player.GetComponent<playerMovement>().changeDimensionalMovement();
            Player.transform.position = desiredPlayerPosition.transform.position;
            mainCam.GetComponent<cameraBehavior>().toggleFollow();
            mainCam.transform.position = desiredCameraPosition.transform.position;
        }
    }
}
