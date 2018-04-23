using UnityEngine;
using System.Collections;

public class CameraController2AA : MonoBehaviour
{

    public GameObject PlayerCube;

    private Vector3 offset;

    void Start()
    {
        Debug.Log("CameraConroller2AA::Start()!");
        offset = transform.position - PlayerCube.transform.position;
    }

    void LateUpdate()
    {
        Debug.Log("CameraConroller2AA::LateUpdate()!");
        transform.position = PlayerCube.transform.position + offset;
    }
}    
