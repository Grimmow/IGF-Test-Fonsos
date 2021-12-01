using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float rotationSpeed = 8f;
    float translation;
    float rotation;

    void Update()  
    {
        translation = Input.GetAxis("Vertical") * speed;
         rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(rotation, 0, translation);
    }
}
