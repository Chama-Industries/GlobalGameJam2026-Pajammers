using UnityEngine;

public class twoDimensionalObjectBehavior : MonoBehaviour
{
    GameObject mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void FixedUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}
