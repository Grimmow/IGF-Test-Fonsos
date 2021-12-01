using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseSensetivity = 100f;
    [SerializeField] Transform offset;
    [SerializeField] Transform playerBody;

    void Start()   // kryboume to pontiki kai leme sthn kamera na koitaei opou koitaei to pontiki
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera.main.transform.LookAt(offset);
    }

    void Update()   //leme sthn kamera n allazei thesh analoga me thn kinhsh tou pontikioy stous aksones x kai y
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
