using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MnKrotate : MonoBehaviour
{
    public float rotationSpeed = 5;
    float speed = 5;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Rotate();
        //}

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }



        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        //rotate left and right

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -speed*10 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, speed * 10 * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }



    }
      
    
    private void Rotate()
    {


        float Y = Input.GetAxis("Mouse Y") * rotationSpeed;
        float X = Input.GetAxis("Mouse X") * rotationSpeed;
        
        transform.Rotate(Vector3.up, X, Space.Self);
       

    }



}
