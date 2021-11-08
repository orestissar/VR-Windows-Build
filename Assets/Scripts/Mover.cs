using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Mover : MonoBehaviour
{
    private InputDevice _device;
    private CharacterController _character;
    private Vector2 _inputStick;
    private GameObject _camera;

    private void Start()
    {
        _device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        _character = GetComponent<CharacterController>();
        _camera = GetComponent<XRRig>().cameraGameObject;
    }


    private void Update()
    {
        _device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputStick);


        var inputVector = new Vector3(_inputStick.x, 0, _inputStick.y);
        var inputDirection = transform.TransformDirection(inputVector);
        var lookDirection = new Vector3(0, _camera.transform.eulerAngles.y, 0);
        var newDirection = Quaternion.Euler(lookDirection) * inputDirection;

        _character.Move(newDirection* Time.deltaTime * 1f);
    }
}
