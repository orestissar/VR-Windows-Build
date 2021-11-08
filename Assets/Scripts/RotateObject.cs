using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 5;
    
    private InputDevice _device;
    private Vector2 _controllerPos;
   

    
    private void Start()
    {
        _device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    OnMouseDrag();
        //}
        if (_device.IsPressed(InputHelpers.Button.Primary2DAxisTouch, out bool isPressedPrimaryButton) && isPressedPrimaryButton)
        {
            //Debug.Log("1");
            Rotate();
        }

    }
    private void Rotate()
    {

        _device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _controllerPos);
        
        float Y = _controllerPos.x * rotationSpeed;
        float X = _controllerPos.y * rotationSpeed;

        Debug.Log(X + "+" + Y);

        transform.Rotate(Vector3.up, X, Space.Self);
        //transform.Rotate(Vector3.right, Y, Space.Self);

    }

    

}
