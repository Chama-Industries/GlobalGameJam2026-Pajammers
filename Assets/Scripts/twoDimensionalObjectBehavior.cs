using UnityEngine;

public class twoDimensionalObjectBehavior : MonoBehaviour
{
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}
