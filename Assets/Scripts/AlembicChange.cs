using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Playables;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class AlembicChange : MonoBehaviour
{
    
    public GameObject[] alembics;
    int click = 0;
    float speed;
    float smoothness;
    float metallic;
    int play = 0;

    private InputDevice _device;
    private Vector2 _controllerPos;


    void SpawnAlembic()
    {
        play = 0;
        alembics[click].GetComponent<PlayableDirector>().enabled = true;
        for (int i = 0; i < alembics.Length; i++)
        {
            alembics[i].SetActive(false);
        }
        alembics[click].SetActive(true);
        alembics[click].GetComponent<PlayableDirector>().time = Time.time;
    }
    //Next Alembic
    public void ChangeRight()
    {
        click += 1;
        if (click > alembics.Length-1)
        {
            click = 0;
        }
        SpawnAlembic();
    }
    //Previous Alembic
    public void ChangeLeft()
    {
        if (click >= 0)
        {
            click -= 1;
        }
        if (click < 0)
        {
            click = alembics.Length - 1;
        }
        SpawnAlembic();
    }

    public void doPlay()
    {
        alembics[click].GetComponent<PlayableDirector>().enabled = true;
        
    }
    public void doPause()
    {
        alembics[click].GetComponent<PlayableDirector>().enabled=false;
    }
    public void exitplay()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();

    }


    public void PlayPause()
    {
        play += 1;
        if (play % 2 == 1)
        {
            doPause();
        }
        if (play % 2 == 0)
        {
            doPlay();
        }
    }



    public void SliderControl(float value)
    {

        speed = value;
       
        PlayableDirector director = alembics[click].GetComponent<PlayableDirector>();
        director.playableGraph.GetRootPlayable(0).SetSpeed(speed / 10);
        if (speed <= 0.5)
        {
            speed = 1;
        }
        Debug.Log(speed);
    }

    public void Glosyness(float value)
    {
        
        smoothness = 0;        

        var v = alembics[click].transform.GetChild(1).childCount;
        //Debug.Log(alembics[click].transform.GetChild(1).name + " : "+ v);
        Transform child = alembics[click].transform.GetChild(1).GetChild(v - 1);       
               
        //var glosyness = child.GetComponentInChildren<Renderer>().sharedMaterial;

        child.GetComponentInChildren<Renderer>().sharedMaterial.SetFloat("_GlossMapScale", smoothness);
        
        child.GetComponentInChildren<Renderer>().sharedMaterial.SetFloat("_Glossiness", smoothness);
        
    }

    public void Metallic(float value)
    {
       
        metallic = 0;
        var v = alembics[click].transform.GetChild(1).childCount;
        //Debug.Log(alembics[click].transform.GetChild(1).name + " : " + v);
        Transform child = alembics[click].transform.GetChild(1).GetChild(v - 1);
               
        //var glosyness = child.GetComponentInChildren<Renderer>().sharedMaterial;

        child.GetComponentInChildren<Renderer>().sharedMaterial.SetFloat("_GlossMapScale", metallic);
        child.GetComponentInChildren<Renderer>().sharedMaterial.SetFloat("_Metallic", metallic);
        
       
    }
    //private void Start()
    //{
    //    _device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    //}


    //private void Update()
    //{       
    //    if (_device.IsPressed(InputHelpers.Button.Primary2DAxisTouch, out bool isPressedPrimaryButton) && isPressedPrimaryButton)
    //    {
    //        //Debug.Log("1");
    //        Rotate();
    //    }

    //}
    //private void Rotate()
    //{
    //   _device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _controllerPos);

    //    float X = _controllerPos.x * 1;
    //    float Y = _controllerPos.y * 1;

    //    Debug.Log(X + "+" + Y);

    //    transform.Rotate(Vector3.right, Y, Space.Self);
        

    //}



}
