using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SmoothTurning : MonoBehaviour
{
    private InputDevice device;

    private InputDevice deviceLeft;

    private Vector2 inputStick;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool Abutton;
    private bool Bbutton;

    private bool MenuToggle;
    public GameObject setactive;

    public GameObject offset;
    float click = 0;



    bool menuLastState = false;


    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        deviceLeft= InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        originalPosition = offset.transform.position;
        originalRotation = offset.transform.rotation;
        menuLastState = false;

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            activate();
        }
               
        
        
        device.TryGetFeatureValue(CommonUsages.primaryButton, out Abutton);       
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out Abutton) && Abutton)
        {
            Debug.Log("Main button pressed");
            Reset();
        }


        device.TryGetFeatureValue(CommonUsages.secondaryButton, out MenuToggle);
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out MenuToggle))
        {            
            if(MenuToggle != menuLastState)
            {
                click += 1;
                Debug.Log(click);
                if(click % 2 == 0)
                {
                    activate();
                }                

                menuLastState = MenuToggle;
            }
                                   
        }             
    }
      
    void activate()
    {        

        if (setactive.activeSelf)
        {
            setactive.SetActive(false);
        }
        else
        {
            setactive.SetActive(true);
        }
        
    }

    public void ExitPlay()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit ();
        #endif

    }
    private void Reset()
    {
        offset.transform.position = originalPosition;
        offset.transform.rotation = originalRotation;
    }
}
